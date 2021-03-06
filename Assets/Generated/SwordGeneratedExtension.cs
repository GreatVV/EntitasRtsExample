//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Entity {

        static readonly Sword swordComponent = new Sword();

        public bool isSword {
            get { return HasComponent(ComponentIds.Sword); }
            set {
                if(value != isSword) {
                    if(value) {
                        AddComponent(ComponentIds.Sword, swordComponent);
                    } else {
                        RemoveComponent(ComponentIds.Sword);
                    }
                }
            }
        }

        public Entity IsSword(bool value) {
            isSword = value;
            return this;
        }
    }

    public partial class Matcher {

        static IMatcher _matcherSword;

        public static IMatcher Sword {
            get {
                if(_matcherSword == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Sword);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSword = matcher;
                }

                return _matcherSword;
            }
        }
    }
}
