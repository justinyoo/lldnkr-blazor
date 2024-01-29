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

![커넥트포게임이미지](https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/Connect_Four.jpg/330px-Connect_Four.jpg) <br/>

우리가 만드는 게임은 사진과 같은 보드게임을 만드는 것입니다.
이 게임은 번갈아 조각을 떨어뜨리고 4개를 먼저 연결하면 이기는 게임입니다.
이제 화면에 보드판을 표시하였으니 조각을 떨어뜨리고 승패를 판정하는 로직을 넣어야 합니다.

### 게임 상태 추가하기
먼저 게임 상태를 관리하는 클래스를 추가하겠습니다. 

1. [GameState.cs 파일](./1-complete/ConnectFour/GameState.cs)을 복사하여 프로젝트에 추가합니다. <br/>
이 클래스는 게임 상태를 처리하는 로직이 들어있습니다.

1. GameState 클래스를 사용할 수 있도록 Programs.cs 파일에 Singleton으로 추가합니다.
네임스페이스를 추가하시는 것을 잊지 마세요.

    ```
    using ConnectFour;
    ```

    ```
    builder.Services.AddSingleton<GameState>();
    ```

### 게임 상태 초기화

1. Board 컴포넌트가 시작할 때 게임 상태도 초기화되는 것이 좋겠습니다.
Board.razor 파일 최상단에 아래 코드를 추가해주면 GameState 클래스를 State라는 이름으로 사용하겠다는 뜻입니다. Program.cs에서 추가해준 인스턴스를 그대로 사용하는 것입니다.

    ```
    @inject GameState State
    ```

1.  Board.razor 파일의 코드 블럭에 OnInitialized 메서드에 GameState를 초기화하는 코드를 추가합니다.

    ```
    protected override void OnInitialized()
    {
        State.ResetBoard();
    }
    ```

### 게임 말 추가하기
이제 게임 말을 하나씩 추가해 보겠습니다. Board.razor 파일을 수정하여 구현합니다.

1. 게임 말 정보를 보관할 배열을 선언합니다.
    ```
    private string[] pieces = new string[42];
    ```
1. 게임 말의 역할을 맡아줄 42개의 HTML을 추가합니다.
    ```
    @for (var i = 0; i < 42; i++)
    {
       <span class="@pieces[i]"></span>
    }
    ```

### 게임 말 떨어뜨리기
다음으로는 플레이어가 각 열에 게임말을 떨어뜨렸을 때의 처리를 구현해 보죠.<br/>
GameState 클래스는 누구 차례인지 게임 보드판이 어떤 상태인지 이미 모두 알고 있습니다.<br/>
GameState에서 정보를 얻어서 게임말을 떨어뜨리는 메서드를 아래와 같이 구현할 수 있습니다.

1. Board.razor 코드 블럭에 아래 메서드를 추가해 주세요.
    ```
    private void PlayPiece(byte col)
    {
        var player = State.PlayerTurn;
        var turn = State.CurrentTurn;
        var landingRow = State.PlayPiece(col);
        pieces[turn] = $"player{player} col{col} drop{landingRow}";
    }
    ```

### 보드판의 열 선택
게임 말을 떨어뜨리는 기능이 구현되었으니 보드판에서 열을 선택해서 떨어뜨려 봅시다.
보드판 각 열 위에 "🔽"을 클릭해서 선택할 수 있게 합니다.

1. 클릭할 수 있게 버튼 위에 추가해 주는 <div> 태그를 추가해 주세요.
    ```
    <nav>
        @for (byte i = 0; i < 7; i++)
        {
            var piece = i;
            <span title="Click to play a piece" @onclick="() => PlayPiece(piece)">🔽</span>
        }
    </nav>
    ```
    @onclick 속성은 클릭 이벤트에 이벤트 핸들러를 지정합니다. 하지만 UI 이벤트를 처리하기 위해서는 Blazor Component가 interactive render mode여야 합니다. Blazor Component는 기본적으로 Static Render이므로 @rendermode 속성을 변경해줘야 합니다.

1. @rendermode를 변경하기 위해서는 Home.razor 파일의 Board 속성을 아래와 같이 추가합니다.
    ```
    <Board @rendermode="InteractiveServer" />
    ```
1. 아래 그림처럼 되면 성공입니다.<br/>
    ![열선택 이미지](https://github.com/dotnet/intro-to-dotnet-web-dev/raw/main/5-blazor/img/2-board-drop.gif)

### 승패 판정과 에러 처리
이제 원하는 곳에 게임말을 번갈아 놓아 떨어뜨릴 수 있게 되었습니다. 하지만 누가 이겼는지는 알 수가 없네요. 그리고 한 줄에 너무 많은 게임말을 떨어뜨리면 오류가 발생합니다. 이래선 안 되겠네요. 수정해 보죠.

1. 열 선택 버튼 밑에 승패에 대한 메시지나 오류에 대한 메시지를 표시할 수 있는 자리를 추가합니다.
    ```
    <article>
      @winnerMessage  <button style="@ResetStyle" @onclick="ResetGame">Reset the game</button>
      <br />
      <span class="alert-danger">@errorMessage</span>
      <span class="alert-info">@CurrentTurn</span>
    </article>
    ```
    자세히 보면 승패 및 오류에 대한 표시 그리고 이번이 누구 차례인가를 표시하게 되어 있네요. 아직은 자리만 잡은 상태이고 에러가 납니다.

1. 이제 에러가 나지 않게 변수를 선언해 주세요.
    ```
    private string winnerMessage = string.Empty;
    private string errorMessage = string.Empty;

    private string CurrentTurn => (winnerMessage == string.Empty) ? $"Player {State.PlayerTurn}'s Turn" : "";
    private string ResetStyle => (winnerMessage == string.Empty) ? "display: none;" : "";
    ```

1. 그럼 이제 게임말을 내려 놓는 메서드에서 GameState에서 발생한 예외와 게임판정에 대한 메시지를 표시하도록 변경해 봅시다.

    ```
    private void PlayPiece(byte col)
    {
      errorMessage = string.Empty;
      try
      {
        var player = State.PlayerTurn;
        var turn = State.CurrentTurn;
        var landingRow = State.PlayPiece(col);
        pieces[turn] = $"player{player} col{col} drop{landingRow}";
      }
      catch (ArgumentException ex)
      {
        errorMessage = ex.Message;
      }

      winnerMessage = State.CheckForWin() switch
      {
        GameState.WinState.Player1_Wins => "Player 1 Wins!",
        GameState.WinState.Player2_Wins => "Player 2 Wins!",
        GameState.WinState.Tie => "It's a tie!",
        _ => ""
      };
    }
    ```

1. 새로 추가된 내용에 승패가 정해지고 나면 다시 시작하는 버튼이 있습니다. 게임 상태를 초기화 하는 메서드도 추가합니다.
    ```
    void ResetGame()
    {
        State.ResetBoard();
        winnerMessage = string.Empty;
        errorMessage = string.Empty;
        pieces = new string[42];
    }
    ```

이제 게임이 만들어졌네요. 누가 이겼는지도 알 수 있고 다시 시작할 수도 있습니다.<br/>
다음은 게임 보드의 색을 커스터마이징하는 방법을 알아보겠습니다.

## 게임 보드 커스터마이징하기

우리가 만든 게임은 Board 컴포넌트가 처리합니다. Board 속성으로 게임 보드판의 색상을 지정하도록 변경해 보겠습니다. 

1. Board.razor파일의 코드 블럭에 속성을 지정할 수 있도록 아래 코드를 추가합니다.

    ```
    [Parameter]
    public Color BoardColor { get; set; } = ColorTranslator.FromHtml("yellow");

    [Parameter]
    public Color Player1Color { get; set; } = ColorTranslator.FromHtml("red");

    [Parameter]
    public Color Player2Color { get; set; } = ColorTranslator.FromHtml("blue");
    ```

1. 색상과 관련해서 네임스페이스를 추가합니다.
    ```
    @using System.Drawing
    ```

1. Home.razor에서 Board 태그의 속성을 지정하면 색상이 바뀝니다.
    ```
    <Board @rendermode="InteractiveServer"
      BoardColor="System.Drawing.Color.Black"
      Player1Color="System.Drawing.Color.Green"
      Player2Color="System.Drawing.Color.Purple" />
    ```

## 테스트 프로젝트 추가하기

### MSTEST 프로젝트 추가
단위 테스트를 위해서는 별도의 테스트 프로젝트를 추가합니다.
여기에서는 테스트보다는 커넥트포 프로젝트의 코드 결과를 화면으로 확인하는 용도로 사용합니다.

1. dotnet new 명령어를 통해 새로운 프로젝트를 추가합니다.
    ```
    dotnet new mstest --name ConnectFourTest
    ```

1. 테스트 프로젝트에서 커넥트포 프로젝트의 코드를 사용할 수 있도록 참조를 추가합니다.
    ```
    dotnet add .\ConnectFourTest\ reference .\ConnectFour\
    ```

1. 솔루션에 테스트 프로젝트를 추가해 주세요.
    ```
    dotnet sln add .\ConnectFourTest\
    ```

이제 테스트 코드를 작성하기 위한 준비는 모두 마쳤습니다.

### 테스트 코드 추가
테스트 프로젝트에는 UnitTest1.cs 파일이 있고 TestMethod1메서드가 실행됩니다.
GaemState의 처리를 알아보기 위해서 아래 코드로 변경해 주세요.

1. UnitTest1.cs파일의 최상단에 using을 추가합니다. 
    ```
    using ConnectFour;
    ```
1. UnitTest1.cs파일의 TestMethod1 메서드를 아래와 같이 수정합니다.
    ```
      [TestMethod]
      public void TestMethod1()
      {
        GameState State = new();
        State.ResetBoard();

        {
          var col = 0;
          var player = State.PlayerTurn;
          var turn = State.CurrentTurn;
          var landingRow = State.PlayPiece(col);
          var result = $"player{player} col{col} drop{landingRow}";
          Console.WriteLine(result);
        }

        {
          var col = 0;
          var player = State.PlayerTurn;
          var turn = State.CurrentTurn;
          var landingRow = State.PlayPiece(col);
          var result = $"player{player} col{col} drop{landingRow}";
          Console.WriteLine(result);
        }

        {
          var winner = State.CheckForWin();
          Console.WriteLine(winner);
        }
      }
    ```
1. 터미널에서 아래 명령어를 실행시켜 테스트프로젝트를 실행해서 결과를 확인해 보죠.
    ```
    dotnet test --logger "console;verbosity=detailed" .\ConnectFourTest\
    ```
1. 아래와 같이 결과가 나왔으면 정상입니다.
    ```
      통과 TestMethod1 [3 ms]
      표준 출력 메시지:
     player1 col0 drop6
     player2 col0 drop5
     No_Winner



    테스트를 실행했습니다.
    총 테스트 수: 1
         통과: 1
     총 시간: 0.4941 초
    ```
    Board에서 게임말을 놓으면 처리하는 내용을 확인해 보았습니다.