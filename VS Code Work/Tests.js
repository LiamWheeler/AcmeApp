var str = "asdfghjkl"
var rts = str.split("").reverse("").join("");
if(str == rts){
    console.log("Is a Palindrome")
}
else console.log("Not a Palindrome")



var x = [[1,2,3],[4,5,6],[7,8,9]]
console.log(x[1][2]);




var word = "aallbbc";
const countLetters = (word) => {
    letters = {}
    for (i = 0; i < word.length; i++){
    if(word[i] in letters){
        letters[word[i]] += 1
    }
    else{
        letters[word[i]] = 1
    }
}
    return letters
}


console.log(countLetters(word))

const checkPal = (word) => {
    letters = countLetters(word)
    lettersAvailable = Object.keys(letters)
    oddNumbers = 0
    for(let i of lettersAvailable){
    if (letters[i] % 2 == 1){
        oddNumbers += 1
    }

    if (oddNumbers >=2){
        return false
    }
    else{
        return true
    }
}
}

console.log(checkPal(word))

let array = ["alpha", "brave", "charlie"];
let object = {
    a: "a",
    b: "b",
    c:"c",
}

for (let item of array){
    console.log(item)
}

for(let item in object){
    console.log(item)
}


let myArray = ["Sam", "Stu", "Dean", "Andy", "Dan"]
console.log(myArray.sort());