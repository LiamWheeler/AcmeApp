class Rabbit
{
    constructor(name){
        this._name = name
        this._hops = 0 
    }
    get name(){
        return this._name
    }
    get hops(){
        return this._hops
    }
    increasehops(){
        this._hops++
    }
}
const Liam = new Rabbit("Liam");
console.log(Liam)