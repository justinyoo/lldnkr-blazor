# Let's Learn .NET - Blazor (한국어) 데모 코드

Let's Learn .NET - Blazor (한국어) 세션의 데모 코드를 저장한 곳입니다.

## 사전 준비 사항

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0) 이상
- [Visual Studio Code](https://code.visualstudio.com/) + [C# Dev Kit 익스텐션](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## 새 Blazor 프로젝트 만들기

1. 아래 명령어를 실행시켜 Blazor 프로젝트를 위한 환경 설정 파일을 만듭니다.

    ```bash
    # .gitignore 파일 생성
    dotnet new gitignore

    # .editorconfig 파일 생성
    dotnet new editorconfig

    # global.json 파일 생성
    dotnet new globaljson
    ```

1. 아래 명령어를 통해 새 Blazor 프로젝트를 만듭니다.

    ```bash
    dotnet new blazor -n ConnectFour
    ```

1. 아래 명령어를 통해 새 솔루션 파일을 만듭니다.

    ```bash
    dotnet new sln -n ConnectFour
    ```

1. 아래 명령어를 통해 솔루션 파일에 프로젝트를 추가합니다.

    ```bash
    dotnet sln add ./ConnectFour/
    ```

1. 아래 명령어를 통해 프로젝트를 빌드합니다.

    ```bash
    dotnet restore && dotnet build
    ```

1. 아래 명령어를 통해 Blazor 프로젝트를 실행합니다.

    ```bash
    dotnet watch run --project ./ConnectFour/
    ```

## 게임 보드 컴포넌트 만들기

1. `Components` 폴더 아래 `Board.razor` 파일을 만듭니다.

1. `Components/Pages` 폴더 아래 `Home.razor` 파일을 열고 아래와 같이 수정합니다.

    ```razor
    @page "/"
    
    <PageTitle>Index</PageTitle>
    <Board />
    ```

1. `Board.razor` 파일의 내용을 아래와 같이 수정합니다.

    ```razor
    <div>
       <div class="board">
          @for (var i = 0; i < 42; i++)
          {
             <span class="container">
                <span></span>
             </span>
          }
       </div>
    </div>
    ```

1. `<div>...</div>` 위에 아래 내용을 추가합니다.

    ```razor
    <HeadContent>
        <style>
            :root {
                --board-bg: yellow;  /** the color of the board **/
                --player1: red;      /** Player 1's piece color **/
                --player2: blue;     /** Player 2's piece color **/
            }
        </style>
    </HeadContent>
    ```

1. `Components` 폴더 아래 `Board.razor.css` 파일을 만들고 아래 내용을 추가합니다.

    ```css
    div {
      position: relative;
    }
    
    nav {
      top: 4em;
      width: 30em;
      display: inline-flex;
      flex-direction: row;
      margin-left: 10px;
    }
    
    nav span {
      width: 4em;
      text-align: center;
      cursor: pointer;
      font-size: 1em;
    }
    
    div.board {
      margin-top: 1em;
      flex-wrap: wrap;
      width: 30em;
      height: 24em;
      overflow: hidden;
      display: inline-flex;
      flex-direction: row;
      flex-wrap: wrap;
      z-index: -5;
      row-gap: 0;
      pointer-events: none;
      border-left: 10px solid var(--board-bg);
    }
    
    span.container {
      width: 4em;
      height: 4em;
      margin: 0;
      padding: 4px;
      overflow: hidden;
      background-color: transparent;
      position: relative;
      z-index: -2;
      pointer-events: none;
    }
    
    .container span {
      width: 3.5em;
      height: 3.5em;
      border-radius: 50%;
      box-shadow: 0 0 0 3em var(--board-bg);
      left: 0px;
      position: absolute;
      display: block;
      z-index: 5;
      pointer-events: none;
    }
    
    .player1, .player2 {
      width: 3.5em;
      height: 3.5em;
      border-radius: 50%;
      left: 0px;
      top: 0px;
      position: absolute;
      display: block;
      z-index: -8;
    }
    
    .player1 {
      background-color: var(--player1);
      animation-timing-function: cubic-bezier(.5, 0.05, 1, .5);
      animation-iteration-count: 1;
      animation-fill-mode: forwards;
      box-shadow: 0 0 0 4px var(--player1);
    }
    
    .player2 {
      background-color: var(--player2);
      animation-timing-function: cubic-bezier(.5, 0.05, 1, .5);
      animation-iteration-count: 1;
      animation-fill-mode: forwards;
      box-shadow: 0 0 0 4px var(--player2);
    }
    
    .col0 {
      left: calc(0em + 9px);
    }
    
    .col1 {
      left: calc(4em + 9px);
    }
    
    .col2 {
      left: calc(8em + 9px);
    }
    
    .col3 {
      left: calc(12em + 9px);
    }
    
    .col4 {
      left: calc(16em + 9px);
    }
    
    .col5 {
      left: calc(20em + 9px);
    }
    
    .col6 {
      left: calc(24em + 9px);
    }
    
    .drop1 {
      animation-duration: 1s;
      animation-name: drop1;
    }
    
    .drop2 {
      animation-duration: 1.5s;
      animation-name: drop2;
    }
    
    .drop3 {
      animation-duration: 1.6s;
      animation-name: drop3;
    }
    
    .drop4 {
      animation-duration: 1.7s;
      animation-name: drop4;
    }
    
    .drop5 {
      animation-duration: 1.8s;
      animation-name: drop5;
    }
    
    .drop6 {
      animation-duration: 1.9s;
      animation-name: drop6;
    }
    
    @keyframes drop1 {
      75%, 90%, 97%, 100% {
        transform: translateY(1.27em);
      }
    
      80% {
        transform: translateY(0.4em);
      }
    
      /*-15% */
      95% {
        transform: translateY(0.8em);
      }
    
      /* -7% */
      99% {
        transform: translateY(1.0em);
      }
    
      /* -3% */
    }
    
    @keyframes drop2 {
      75%, 90%, 97%, 100% {
        transform: translateY(5.27em);
      }
    
      80% {
        transform: translateY(3.8em);
      }
    
      /*-15% */
      95% {
        transform: translateY(4.6em);
      }
    
      /* -7% */
      99% {
        transform: translateY(4.9em);
      }
    
      /* -3% */
    }
    
    @keyframes drop3 {
      75%, 90%, 97%, 100% {
        transform: translateY(9.27em);
      }
    
      80% {
        transform: translateY(7.2em);
      }
    
      /*-15% */
      95% {
        transform: translateY(8.3em);
      }
    
      /* -7% */
      99% {
        transform: translateY(8.8em);
      }
    
      /* -3% */
    }
    
    @keyframes drop4 {
      75%, 90%, 97%, 100% {
        transform: translateY(13.27em);
      }
    
      80% {
        transform: translateY(10.6em);
      }
    
      /*-15% */
      95% {
        transform: translateY(12em);
      }
    
      /* -7% */
      99% {
        transform: translateY(12.7em);
      }
    
      /* -3% */
    }
    
    @keyframes drop5 {
      75%, 90%, 97%, 100% {
        transform: translateY(17.27em);
      }
    
      80% {
        transform: translateY(14em);
      }
    
      /*-15% */
      95% {
        transform: translateY(15.7em);
      }
    
      /* -7% */
      99% {
        transform: translateY(16.5em);
      }
    
      /* -3% */
    }
    
    @keyframes drop6 {
      75%, 90%, 97%, 100% {
        transform: translateY(21.27em);
      }
    
      80% {
        transform: translateY(17.4em);
      }
    
      95% {
        transform: translateY(19.4em);
      }
    
      99% {
        transform: translateY(20.4em);
      }
    }
    ```

1. 아래 명령어를 통해 프로젝트를 빌드합니다.

    ```bash
    dotnet build
    ```

1. 아래 명령어를 통해 Blazor 프로젝트를 실행합니다.

    ```bash
    dotnet watch run --project ./ConnectFour/
    ```

## 게임 로직 추가하기

TBD

## 게임 보드 커스터마이징하기

TBD
