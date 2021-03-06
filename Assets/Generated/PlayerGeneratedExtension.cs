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

        public Player player { get { return (Player)GetComponent(ComponentIds.Player); } }
        public bool hasPlayer { get { return HasComponent(ComponentIds.Player); } }

        public Entity AddPlayer(int newId) {
            var component = CreateComponent<Player>(ComponentIds.Player);
            component.Id = newId;
            return AddComponent(ComponentIds.Player, component);
        }

        public Entity ReplacePlayer(int newId) {
            var component = CreateComponent<Player>(ComponentIds.Player);
            component.Id = newId;
            ReplaceComponent(ComponentIds.Player, component);
            return this;
        }

        public Entity RemovePlayer() {
            return RemoveComponent(ComponentIds.Player);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherPlayer;

        public static IMatcher Player {
            get {
                if(_matcherPlayer == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Player);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPlayer = matcher;
                }

                return _matcherPlayer;
            }
        }
    }
}
