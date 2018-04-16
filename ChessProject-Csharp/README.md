
# Considerations
- .Net framework. Prior to commencing the sprint I would consider changing to .Net Core or .Net Standard, depending on the use-case of the chess library.

# Notes

- The chessboard setup should, in time, receive a pre-defined board setup of pieces. The ChessBoard contructor currently receives all pieces, which could be used to load a board setup.
- A bootstrap method to setup all pieces, making use of ChessBoard.Add(), is probably an improved loading solution.
- The LegalPositions class can be extended to deal with position where a piece can be captured.
- Piece Move had been moved to out of the Piece object and onto the chessboard. I envisage that MovementType should not be required, and application logic would determine whether a piece being moved is capturing or not.
- To provide further functionality, such as the ability to undo moves/captures, I would consider using the command pattern to create a command for a move and capture, which would store the required state to roll back commands. This would be more flexible as the project develops.

- The initial project tests had mixed up the definition of what coordinates x and y were relative to row and column. One test used x as row and another as a column. It may be easier in the future to move from x/y to row/column naming convention.

