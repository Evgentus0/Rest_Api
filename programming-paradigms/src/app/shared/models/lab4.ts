export class Lab4{
    details:Details[];
    isLL1:boolean;

    constructor(){
        this.details = [];
    }
}

export class Details{
    nonTerminal:string;
    firsts:string[];
    follow:string;

    constructor(){
        this.firsts=[];
    }
}