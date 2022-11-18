using System;
using System.Collections.Generic;

namespace MoD
{
    public abstract class ComponentSystem
    {
        private Dictionary<ComponentType,Dictionary<string,IComponent>> _components = new Dictionary<ComponentType, Dictionary<string, IComponent>>();
        public event Action? OnRun;

        public void Event_OnRun(){
            OnRun?.Invoke();
        }

        public enum ComponentType
        {
            Property,
            Behavior
        }

        public interface IComponent {
            public ComponentType Type {get; }
            public void Register(ComponentSystem owner);
            public void Deregister(ComponentSystem owner);
        }

        

        public class PropertyComponent : IComponent
        {
            public ComponentType Type => ComponentType.Property;
            public string Name = "";
            public string Description = "";
            
            private object? _value;
            public object? Value
            {
                get { return _value; }
                set { _value = value; }
            }

            private ComponentSystem? _owner = null;

            public void Register(ComponentSystem owner)
            {
                _owner = owner;
            }
            public void Deregister(ComponentSystem owner)
            {
                _owner = null;
            }

            public PropertyComponent(ComponentSystem owner, string name, object? value)
            {
                Register(owner);
                Name = name;
                Value = value;
            }

        }

        public abstract class BehaviorComponent : IComponent
        {
            public ComponentType Type => ComponentType.Behavior;
            
            public virtual void OnRun()
            {

            }

            private ComponentSystem? _owner = null;
            public void Register(ComponentSystem owner)
            {
                _owner = owner;
                owner.OnRun += OnRun;
            }
            public void Deregister(ComponentSystem owner)
            {
                _owner = null;
                owner.OnRun -= OnRun;
            }
        }

        public string AddComponent(ComponentType type, IComponent comp, string name="")
        {
            if(name == "")
                name = Guid.NewGuid().ToString();

            if(!_components.ContainsKey(type))
                _components.Add(type, new Dictionary<string, IComponent>());

            if(_components[type].ContainsKey(name)){
                _components[type][name].Deregister(this);
                _components[type].Remove(name);
            }

            _components[type].Add(name,comp);
            _components[type][name].Register(this);

            return name;
        }

        public IComponent? FindComponent(string name)
        {
            foreach(var type in _components.Keys){
                foreach(var icname in _components[type].Keys){
                    if(icname == name)
                        return _components[type][icname];
                }
            }
            
            return null;
        }

        public void RemoveComponent(ComponentType type, string name="")
        {
            if(_components.ContainsKey(type) && _components[type].ContainsKey(name)){
                _components[type][name].Deregister(this);
                _components[type].Remove(name);
            }
        }

        public string AddProperty(string name, object value)
        {
            return AddComponent(ComponentType.Property, new PropertyComponent(this, name, value), name);
        }

        public string SetPropertyValue(string name, object value)
        {
            var type = ComponentType.Property;

            if(!_components.ContainsKey(type))
                _components.Add(type, new Dictionary<string, IComponent>());

            
            if(_components[type].ContainsKey(name)){
                ((PropertyComponent)_components[type][name]).Value = value;
            } else {
                AddProperty(name,value);
            }

            return name;
        }

        public object? GetPropertyValue(string name)
        {
            if(_components[ComponentType.Property].ContainsKey(name))
                return _components[ComponentType.Property][name];
            
            return null;
        }

        public T GetPropertyValue<T>(string name)
        {
            object tmp = GetPropertyValue(name);
            //Console.WriteLine(name);
            //Console.WriteLine(tmp.ToString());
            //Console.WriteLine(typeof(tmp));
            return (T)Convert.ChangeType(tmp, typeof(T));
        }

        


    }

    
    public class TestPlayer : ComponentSystem
    {

    }

    public class HeartBeat : ComponentSystem.BehaviorComponent
    {
        public override void OnRun()
        {
            Console.WriteLine("thump, thump");
        }
    }
    
}