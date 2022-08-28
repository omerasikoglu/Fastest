using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Composite {
    public class Composite : MonoBehaviour {

        private IAbility ability = new DelayedDecorator(new RageAbility());


        private SequenceComposite sequenceComposite = new SequenceComposite(new IAbility[]
        {
            new HealAbility(),
            new RageAbility(),
            new DelayedDecorator(new RageAbility()),
        });

        public void Awake() {
            //ability.Use(gameObject);
            sequenceComposite.Use(gameObject);
        }
    }

    public interface IAbility {
        void Use(GameObject gameObject);
    }

    public class SequenceComposite : IAbility {

        private IAbility[] children;

        public SequenceComposite(IAbility[] children) {
            this.children = children;
        }

        public void Use(GameObject currentGameObject) {

            foreach (IAbility child in children) {
                child.Use(currentGameObject);
            }
        }
    }

    public class DelayedDecorator : IAbility {

        private IAbility wrappedAbility;

        public DelayedDecorator(IAbility wrappedAbility) {
            this.wrappedAbility = wrappedAbility;
        }

        public void Use(GameObject gameObject) {
            Debug.Log("DelayedDecorator");
            wrappedAbility.Use(gameObject);
        }
    }

    public class RageAbility : IAbility {
        public void Use(GameObject gameObject) {
            Debug.Log("RageAbility");
        }
    }

    public class HealAbility : IAbility {
        public void Use(GameObject gameObject) {
            Debug.Log("HealAbility");
        }
    }

}
