let naughtsAndCrosses = {
    playerX: "Liam",
    playerO: "Dave",
    grid: [[ 1, 2, 3],[ 4, 5, 6],[ 7, 8, 9]],
    playGame(){
        console.log("   |     |   ")
        console.log(` ${this.grid[0][0]} |  ${this.grid[0][1]}  |  ${this.grid[0][2]} `)
        console.log("   |     |   ")
        console.log("- - - - - - -")
        console.log("   |     |   ")
        console.log(` ${this.grid[1][0]} |  ${this.grid[1][1]}  |  ${this.grid[1][2]}  `)
        console.log("   |     |   ")
        console.log("- - - - - - -")
        console.log("   |     |   ")
        console.log(` ${this.grid[2][0]} |  ${this.grid[2][1]}  |  ${this.grid[2][2]} `)
        console.log("   |     |   ")
    },
    moves(row, column, xOrO){
    if (xOrO === this.playerX){return (this.grid[row-1][column-1] = "X")}
    else if (xOrO === this.playerO){return(this.grid[row-1][column-1] = "O")}
    else return (this.grid[row-1][column-1] = " ")
},
    check(var1, var2, var3){
       if (var1 == "X" && var2 == "X" && var3 == "X"){
       return (true)
       }else if (var1 == "O" && var2 == "O" && var3 == "O")
       {return (true)
       }else {return (false)
    }
},
    winner(){
        for (i = 0; i <3; i++) {
        if (this.check(this.grid[0][i], this.grid[1][i], this.grid[2][i])){
        return true}
        else if (this.check(this.grid[i][0], this.grid[i][1], this.grid[i][2])){
        return true}
        else if (this.check(this.grid[0][0], this.grid[1][1], this.grid[2][2])){
        return true}
        else if (this.check(this.grid[2][0], this.grid[1][1], this.grid[0][2])){
        return true}
        }
        return (false)
    }, 

    message(){
        if (this.winner() === true){
            console.log("Winner")
        }
        else console.log("No Winner")
    }
   
}



naughtsAndCrosses.moves(1,1,"Dave")
naughtsAndCrosses.moves(1,2,"Liam")
naughtsAndCrosses.moves(1,3,"Liam")
naughtsAndCrosses.moves(2,1,"Liam")
naughtsAndCrosses.moves(2,2,"Liam")
naughtsAndCrosses.moves(2,3,"Dave")
naughtsAndCrosses.moves(3,1,"Dave")
naughtsAndCrosses.moves(3,2,"Dave")
naughtsAndCrosses.moves(3,3,"Liam")
naughtsAndCrosses.playGame()
naughtsAndCrosses.winner(naughtsAndCrosses.check())
naughtsAndCrosses.message()