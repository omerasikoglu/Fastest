using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : MonoBehaviour {

    private IAbility ability = new DelayedDecorator(new RageAbility());

    public void Awake() {
        ability.Use(gameObject);
    }
}

public interface IAbility {
    void Use(GameObject gameObject);
}

public class DelayedDecorator : IAbility {

    private IAbility wrappedAbility;
    public DelayedDecorator(IAbility wrappedAbility) {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject gameObject) {
        wrappedAbility.Use(gameObject);
        Debug.Log("DelayedDecorator");
    }
}


public class RageAbility : IAbility {
    public void Use(GameObject gameObject) {
        Debug.Log("RageAbility");
    }
}
