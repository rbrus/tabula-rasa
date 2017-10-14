module App.View

open App.Types
open App.State

open Fable.Helpers.React
open Fable.Helpers.React.Props

let menuItem label page currentPage dispatcher =
    div
      [ classList  
         [ "menu-item", true
           "menu-item-selected", page = currentPage ] 
        OnClick (fun e -> dispatcher (ViewPage page))
      ]
      [ str label ]

let sidebar currentPage dispatcher =
  aside
    [ ClassName "fit-parent child-space"; Style [ TextAlign "center" ] ]
    [ div 
        [ Style [ TextAlign "center" ] ]
        [ h3 [ Style [ Color "white" ] ] [ str "Zaid Ajaj" ]
          img [ ClassName "profile-img"; Src "/img/default-cuteness.jpg" ] ]
      div 
        [ ClassName "quote" ]
        [ str "Programming, building things and F#" ]
      
      menuItem "Home" Home currentPage dispatcher
      menuItem "Latest Posts" Posts currentPage dispatcher
      menuItem "Featured" Featured currentPage dispatcher
      menuItem "Archive" Archive currentPage dispatcher
      menuItem "Contact" Contact currentPage dispatcher ]

let render state dispatch =

  let pageView page = 
    match page with
    | Home ->  h1 [] [ str "Home" ]
    | Posts -> Posts.View.render state.Posts (PostsMsg >> dispatch)
    | Admin -> Admin.View.render state.Admin (AdminMsg >> dispatch)
    | Featured -> h1 [] [ str "Featured Posts" ]
    | Archive -> h1 [] [ str "Archive" ]
    | Contact -> h1 [] [ str "Contact" ]
    
  div
    [ ]
    [ div
        [ ClassName "sidebar" ]
        [ sidebar state.CurrentPage dispatch ]
      div
        [ ClassName "main-content" ]
        [ pageView state.CurrentPage ] ]