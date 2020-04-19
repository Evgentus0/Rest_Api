export class Automat{
    States:number[];
    StartState:number;
    FinalStates:number[];
    Transitions:Transitions[]

    constructor(){
        this.States = [];
        this.FinalStates = [];
        this.Transitions = [];
    }
}

class Transitions{
    PrevState:number;
    Symbol:string;
    NextState:number;
}