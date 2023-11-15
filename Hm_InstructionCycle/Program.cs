using System;
using System.Collections.Generic;

enum InstructionType
{
    Add,
    Sub,
    Load,
    Store,
    Halt
}

class Instruction
{
    public InstructionType Type { get; set; }
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public int Destination { get; set; }
}

class Processor
{
    private int [] registers = new int [16];
    private int [] memory = new int [1024];
    private int pc;
    private List<Instruction> program;

    public Processor()
    {
        // Initializing the program 
        program = new List<Instruction>
        {
            new Instruction { Type = InstructionType.Load, Operand1 = 100, Destination = 1 },
            new Instruction { Type = InstructionType.Add, Operand1 = 1, Operand2 = 2, Destination = 3 },
            new Instruction { Type = InstructionType.Sub, Operand1 = 3, Operand2 = 4, Destination = 5 },
            new Instruction { Type = InstructionType.Store, Operand1 = 5, Destination = 200 },
            new Instruction { Type = InstructionType.Halt }
        };
    }

    public void RunPipeline()
    {
        for (pc = 0; pc < program.Count; pc++)
        {
            Console.WriteLine($"Cycle {pc + 1}:");

            // Instruction Fetch (IF) stage
            Instruction instruction = FetchInstruction();
            Console.WriteLine($"IF: {instruction.Type} {instruction.Operand1} {instruction.Operand2} {instruction.Destination}");

            // Instruction Decode (ID) stage
            Instruction decodedInstruction = DecodeInstruction(instruction);
            Console.WriteLine($"ID: {decodedInstruction.Type} {decodedInstruction.Operand1} {decodedInstruction.Operand2} {decodedInstruction.Destination}");

            // Operand Fetch (OF) stage
            OperandFetch(decodedInstruction);
            Console.WriteLine($"OF: {decodedInstruction.Type} {decodedInstruction.Operand1} {decodedInstruction.Operand2} {decodedInstruction.Destination}");

            // Instruction Execution (EX) stage
            ExecuteInstruction(decodedInstruction);
            Console.WriteLine($"EX: {decodedInstruction.Type} {decodedInstruction.Operand1} {decodedInstruction.Operand2} {decodedInstruction.Destination}");

            // Operand Writeback (WB) stage
            Writeback(decodedInstruction);
            Console.WriteLine($"WB: {decodedInstruction.Type} {decodedInstruction.Operand1} {decodedInstruction.Operand2} {decodedInstruction.Destination}");

            Console.WriteLine();
        }
    }

    private Instruction FetchInstruction()
    {
        return program [pc];
    }

    private Instruction DecodeInstruction(Instruction instruction)
    {
        // Simplified decoding logic (no changes)
        return instruction;
    }

    private void OperandFetch(Instruction instruction)
    {
        // Simplified operand fetch (no changes)
    }

    private void ExecuteInstruction(Instruction instruction)
    {
        // Simplified execution logic (no changes)
    }

    private void Writeback(Instruction instruction)
    {
        // Simplified writeback (no changes)
    }
}

class Program
{
    static void Main()
    {
        Processor processor = new Processor();
        processor.RunPipeline();
    }
}
