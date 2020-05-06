export default interface ITab {
    id: number;
    name: string;  
    type: TabType;  
    iterations: ITabIteration[];
}

export enum TabType{
    Guitar,
    Drums,
    Piano,
    Any
}

export interface ITabIteration{
    timeScale : number;
} 


export interface IGuitarIteration extends ITabIteration{
    notes: IGuitarNote[];
}

export interface IGuitarNote{
    fret: number;
    string: number;
}


export interface IDrumIteration extends ITabIteration{
    drums: IDrumNote[];
}

export interface IDrumNote{
    drum: DrumType;
}

export enum DrumType{    
        CC2 = 0,        
        BD = 1,        
        xH = 2,        
        S = 3,        
        MT = 4,        
        LT = 5,        
        CC1 = 6,        
        oH = 7,
        HFT = 8,        
        SS = 9,        
        LFT = 10
}


export interface IPianoIteration extends ITabIteration{
    notes: IConcreteNote[];
}

export interface IConcreteNote{
    note : NoteType;
    octave: OctaveType;
}

export enum NoteType{
    C = 1,
    Csharp = 2,
    D = 3,
    Dsharp = 4,
    E = 5,
    F = 6,
    Fsharp = 7,
    G = 8,
    Gsharp = 9,
    A = 10,
    Asharp = 11,
    H = 12
}

export enum OctaveType{
    Contra = 1,
    Great = 2,
    Small = 3,
    FirstLine = 4,
    SecondLine = 5,
    ThirdLine = 6,
    FourthLine = 7
}