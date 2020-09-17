open System
open Akka.FSharp

// child actor to find sqrt
// end optimization

type Command = 
    | Start
    | Answer of Int32
    | Message of Tuple
    | Exit

let child message =
    // child actor
    // what does child actor receive in the queue
    // child actor receives range [start,end]
    // s = 0
    // for i in range(start, end+1):
    //  s += i*i
    //  check if s is perfect square - 
    //  this can be done in O(lgn)
    //  return the result
    printfn "hello child"

let parent message = 
    // spawn a boss actor
    // loop in the boss actor
    // for each i up until N
    // spawn a child actor
    // check the result of the child actor
    // if the result is true
    // printfn "%d" i
    printfn "hello parent"
    printfn message

// create an entry point into the sys
[<EntryPoint>]
let main argv = 
    if (argv.Length < 3) then
        printfn "Format : dotnet run Program.fs N K"
        0
    else
        try
            let n:int32 = argv.[1] |> int
            let k:int32 = argv.[2] |> int
            let myActorSystem = System.create "MyActorSystem" (Configuration.load ())
            let parent = spawn myActorSystem "parentActor" (actorOf parent)
            let t = (n,k)
            parent <! t
            myActorSystem.WhenTerminated.Wait ()
        with :? System.FormatException ->
           printfn "Format : dotnet run Program.fs N K"
           printfn "N and K are integer values"
        0

// next steps
// see how to connect 2 machines in a cluster
// and then be able to spawn actors in 2 machines