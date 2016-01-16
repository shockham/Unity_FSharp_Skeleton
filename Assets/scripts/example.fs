namespace shockham.example

open UnityEngine

type ExampleBehaviour() =
    inherit MonoBehaviour()

    member x.Start() =
        Debug.Log "test"
