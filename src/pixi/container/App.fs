module Pixi

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Pixi
open Fable.Import.Browser
open Fable.Import.JS

// create a new Sprite from an image path
//let options = PIXI.ApplicationOptions.BackgroundColor 0x1099bb 
let options = createEmpty<PIXI.ApplicationOptions>
options.backgroundColor <- Some 0xAAAACC

let app = PIXI.Application(400., 400., options)
Browser.document.body.appendChild(app.view) |> ignore

let container = PIXI.Container()
app.stage.addChild(container) |> ignore

// create a new Sprite from an image path
let texture = PIXI.Texture.fromImage("../fable_logo_small.png")

// Create a 5x5 grid of bunnies
[|0..24|] |> Seq.iter( fun i -> 
    let bunny = PIXI.Sprite(texture)
    bunny.anchor.set(0.5)    
    bunny.x <- float ((i % 5) * 40)
    bunny.y <- Math.floor(float i / 5.) * 40.
    container.addChild(bunny) |> ignore
)

// Center on the screen
let renderer : PIXI.WebGLRenderer = !!app.renderer
container.x <- (renderer.width - container.width) / 2.
container.y <- (renderer.height - container.height) / 2.