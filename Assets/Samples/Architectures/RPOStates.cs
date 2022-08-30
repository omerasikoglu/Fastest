using UnityEngine;

namespace RandomTest {
    public interface IContext {
        void SetResult(IStates state);
    }

    public interface IStates { //rakip taş yapmıştır bu varyasyon üzerinden gidilmektedir.
        void Rock(IContext context);
        void Paper(IContext context);
        void Scissors(IContext context);
        void Octopus(IContext context);
    }

    public class RPOStates : MonoBehaviour, IContext {
        private IStates currentState = new DoRock();

        void Rock() => currentState.Rock(this);
        void Paper() => currentState.Paper(this);
        void Octopus() => currentState.Octopus(this);
        void Scissors() => currentState.Scissors(this);

        public void Start() {
            Debug.Log(currentState.ToString());
        }
        public void SetResult(IStates state) {
            this.currentState = state;
        }
        public void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Rock();
                Debug.Log("You chose Rock |" + currentState);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Paper();
                Debug.Log("You chose Paper |" + currentState);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) {
                Scissors();
                Debug.Log("You chose Scissors |" + currentState);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4)) {
                Octopus();
                Debug.Log("You chose Octopus |" + currentState);
            }
        }
    }

    public class DoRock : IStates {
        public void Rock(IContext context) {

        }

        public void Paper(IContext context) {
            context.SetResult(new DoPaper());
        }

        public void Scissors(IContext context) {

        }

        public void Octopus(IContext context) {
            context.SetResult(new DoOctopus());
        }
        public override string ToString()
        {
            return "Enemy made Rock";
        }
    }
    public class DoPaper : IStates {
        public void Rock(IContext context) {

        }

        public void Paper(IContext context) {

        }

        public void Scissors(IContext context) {
            context.SetResult(new DoScissors());
        }

        public void Octopus(IContext context) {
            context.SetResult(new DoOctopus());
        }
        public override string ToString() {
            return "Enemy made Paper";
        }
    }
    public class DoScissors : IStates {
        public void Rock(IContext context) {
            context.SetResult(new DoRock());
        }

        public void Paper(IContext context) {

        }

        public void Scissors(IContext context) {

        }

        public void Octopus(IContext context) {
            context.SetResult(new DoOctopus());
        }
        public override string ToString() {
            return "Enemy made Scissors";
        }
    }
    public class DoOctopus : IStates {
        public void Rock(IContext context) {
            context.SetResult(new DoRock());
        }

        public void Paper(IContext context) {
            context.SetResult(new DoPaper());
        }

        public void Scissors(IContext context) {
            context.SetResult(new DoScissors());
        }

        public void Octopus(IContext context) {

        }
        public override string ToString() {
            return "Enemy made Octopus";
        }
    }


}