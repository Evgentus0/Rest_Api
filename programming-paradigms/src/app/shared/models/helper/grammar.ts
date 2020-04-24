export class Grammar{
    NonTerminals:string[];
    Terminals:string[];
    Rules:Rule[];

    constructor(){
        this.NonTerminals=[];
        this.Terminals=[];
        this.Rules=[];
    }
}

export class Rule{
    LeftPart:string;
    RightPart:string;
}