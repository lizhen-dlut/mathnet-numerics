// <copyright file="LinearAlgebra.Double.Matrix.fs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
//
// Copyright (c) 2009-2013 Math.NET
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace MathNet.Numerics.LinearAlgebra.Double

open MathNet.Numerics.LinearAlgebra

/// A module which implements functional dense vector operations.
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module DenseMatrix =

    /// Create a matrix that directly binds to a raw storage array in column-major (column by column) format, without copying.
    let inline raw (rows: int) (cols: int) (columnMajor: float[]) = DenseMatrix(rows, cols, columnMajor) :> _ Matrix

    /// Create an all-zero matrix with the given dimension.
    let inline zeroCreate (rows: int) (cols: int) = DenseMatrix(rows, cols) :> _ Matrix

    /// Create a random matrix with the given dimension and value distribution.
    let inline randomCreate (rows: int) (cols: int) dist = DenseMatrix.CreateRandom(rows, cols, dist) :> _ Matrix

    /// Create a matrix with the given dimension and set all values to x.
    let inline create (rows: int) (cols: int) (x: float) = DenseMatrix.Create(rows, cols, x) :> _ Matrix

    /// Create a matrix with the given dimension and set all diagonal values to x. All other values are zero.
    let inline createDiag (rows: int) (cols: int) (x: float) = DenseMatrix.CreateDiagonal(rows, cols, x) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every element.
    let inline init (rows: int) (cols: int) (f: int -> int -> float) = DenseMatrix.Create(rows, cols, fun i j -> f i j) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every row.
    let inline initRows (rows: int) (f: int -> Vector<float>) = DenseMatrix.OfRowVectors(Array.init rows f) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every column.
    let inline initColumns (cols: int) (f: int -> Vector<float>) = DenseMatrix.OfColumnVectors(Array.init cols f) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every diagonal element. All other values are zero.
    let inline initDiag (rows: int) (cols: int) (f: int -> float) = DenseMatrix.CreateDiagonal(rows, cols, f) :> _ Matrix

    /// Create an identity matrix with the given dimension.
    let inline identity (rows: int) (cols: int) = createDiag rows cols 1.0

    /// Create a matrix from a 2D array of floating point numbers.
    let inline ofArray2 array = DenseMatrix.OfArray(array) :> _ Matrix

    /// Create a matrix from a list of row vectors.
    let inline ofRows (rows: Vector<float> list) = DenseMatrix.OfRowVectors(Array.ofList rows) :> _ Matrix

    /// Create a matrix from a list of row arrays.
    let inline ofRowArrays (rows: float[][]) = DenseMatrix.OfRowArrays(rows) :> _ Matrix

    /// Create a matrix from a list of float lists. Every list in the master list specifies a row.
    let inline ofRowList (rows: float list list) = DenseMatrix.OfRowArrays(rows |> List.map List.toArray |> List.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a row.
    let inline ofRowSeq (rows: #seq<#seq<float>>) = DenseMatrix.OfRowArrays(rows |> Seq.map Seq.toArray |> Seq.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a row.
    let inline ofRowSeq2 (rows: int) (cols: int) (seqOfRows: #seq<seq<float>>) = DenseMatrix.OfRows(rows, cols, seqOfRows) :> _ Matrix

    /// Create a matrix from a list of column vectors.
    let inline ofColumns (columns: Vector<float> list) = DenseMatrix.OfColumnVectors(Array.ofList columns) :> _ Matrix

    /// Create a matrix from a list of column arrays.
    let inline ofColumnArrays (columns: float[][]) = DenseMatrix.OfColumnArrays(columns) :> _ Matrix

    /// Create a matrix from a list of float lists. Every list in the master list specifies a column.
    let inline ofColumnList (columns: float list list) = DenseMatrix.OfColumnArrays(columns |> List.map List.toArray |> List.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a column.
    let inline ofColumnSeq (columns: #seq<#seq<float>>) = DenseMatrix.OfColumnArrays(columns |> Seq.map Seq.toArray |> Seq.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a column.
    let inline ofColumnSeq2 (rows: int) (cols: int) (seqOfCols: #seq<seq<float>>) = DenseMatrix.OfColumns(rows, cols, seqOfCols) :> _ Matrix

    /// Create a matrix with a given dimension from an indexed list of row, column, value tuples.
    let inline ofListi (rows: int) (cols: int) (indexed: list<int * int * float>) = DenseMatrix.OfIndexed(rows, cols, Seq.ofList indexed) :> _ Matrix

    /// Create a matrix with a given dimension from an indexed sequences of row, column, value tuples.
    let inline ofSeqi (rows: int) (cols: int) (indexed: #seq<int * int * float>) = DenseMatrix.OfIndexed(rows, cols, indexed) :> _ Matrix

    /// Create a square matrix with the vector elements on the diagonal.
    let inline ofDiag (v: Vector<float>) = DenseMatrix.OfDiagonalVector(v) :> _ Matrix

    /// Create a matrix with the vector elements on the diagonal.
    let inline ofDiag2 (rows: int) (cols: int) (v: Vector<float>) = DenseMatrix.OfDiagonalVector(rows, cols, v) :> _ Matrix

    /// Create a square matrix with the array elements on the diagonal.
    let inline ofDiagArray (array: float array) = DenseMatrix.OfDiagonalArray(array) :> _ Matrix

    /// Create a matrix with the array elements on the diagonal.
    let inline ofDiagArray2 (rows: int) (cols: int) (array: float array) = DenseMatrix.OfDiagonalArray(rows, cols, array) :> _ Matrix


/// A module which implements functional sparse vector operations.
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module SparseMatrix =

    /// Create an all-zero matrix with the given dimension.
    let inline zeroCreate (rows: int) (cols: int) = SparseMatrix(rows, cols) :> _ Matrix

    /// Create a matrix with the given dimension and set all values to x. Note that a dense matrix would likely be more appropriate.
    let inline create (rows: int) (cols: int) (x: float) = SparseMatrix.Create(rows, cols, x) :> _ Matrix

    /// Create a matrix with the given dimension and set all diagonal values to x. All other values are zero.
    let inline createDiag (rows: int) (cols: int) (x: float) = SparseMatrix.CreateDiagonal(rows, cols, x) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every element.
    let inline init (rows: int) (cols: int) (f: int -> int -> float) = SparseMatrix.Create(rows, cols, fun n m -> f n m) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every row.
    let inline initRows (rows: int) (f: int -> Vector<float>) = SparseMatrix.OfRowVectors(Array.init rows f) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every column.
    let inline initColumns (cols: int) (f: int -> Vector<float>) = SparseMatrix.OfColumnVectors(Array.init cols f) :> _ Matrix

    /// Initialize a matrix by calling a construction function for every diagonal element. All other values are zero.
    let inline initDiag (rows: int) (cols: int) (f: int -> float) = SparseMatrix.CreateDiagonal(rows, cols, f) :> _ Matrix

    /// Create an identity matrix with the given dimension.
    let inline identity (rows: int) (cols: int) = createDiag rows cols 1.0

    /// Create a matrix from a 2D array of floating point numbers.
    let inline ofArray2 array = SparseMatrix.OfArray(array) :> _ Matrix

    /// Create a matrix from a list of row vectors.
    let inline ofRows (rows: Vector<float> list) = SparseMatrix.OfRowVectors(Array.ofList rows) :> _ Matrix

    /// Create a matrix from a list of row arrays.
    let inline ofRowArrays (rows: float[][]) = SparseMatrix.OfRowArrays(rows) :> _ Matrix

    /// Create a matrix from a list of float lists. Every list in the master list specifies a row.
    let inline ofRowList (rows: float list list) = SparseMatrix.OfRowArrays(rows |> List.map List.toArray |> List.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a row.
    let inline ofRowSeq (rows: #seq<#seq<float>>) = SparseMatrix.OfRowArrays(rows |> Seq.map Seq.toArray |> Seq.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a row.
    let inline ofRowSeq2 (rows: int) (cols: int) (seqOfRows: #seq<seq<float>>) = SparseMatrix.OfRows(rows, cols, seqOfRows) :> _ Matrix

    /// Create a matrix from a list of column vectors.
    let inline ofColumns (columns: Vector<float> list) = SparseMatrix.OfColumnVectors(Array.ofList columns) :> _ Matrix

    /// Create a matrix from a list of column arrays.
    let inline ofColumnArrays (columns: float[][]) = SparseMatrix.OfColumnArrays(columns) :> _ Matrix

    /// Create a matrix from a list of float lists. Every list in the master list specifies a column.
    let inline ofColumnList (columns: float list list) = SparseMatrix.OfColumnArrays(columns |> List.map List.toArray |> List.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a column.
    let inline ofColumnSeq (columns: #seq<#seq<float>>) = SparseMatrix.OfColumnArrays(columns |> Seq.map Seq.toArray |> Seq.toArray) :> _ Matrix

    /// Create a matrix from a list of sequences. Every sequence in the master sequence specifies a column.
    let inline ofColumnSeq2 (rows: int) (cols: int) (seqOfCols: #seq<seq<float>>) = SparseMatrix.OfColumns(rows, cols, seqOfCols) :> _ Matrix

    /// Create a matrix with a given dimension from an indexed list of row, column, value tuples.
    let inline ofListi (rows: int) (cols: int) (indexed: list<int * int * float>) = SparseMatrix.OfIndexed(rows, cols, Seq.ofList indexed) :> _ Matrix

    /// Create a matrix with a given dimension from an indexed sequences of row, column, value tuples.
    let inline ofSeqi (rows: int) (cols: int) (indexed: #seq<int * int * float>) = SparseMatrix.OfIndexed(rows, cols, indexed) :> _ Matrix

    /// Create a square matrix with the vector elements on the diagonal.
    let inline ofDiag (v: Vector<float>) = SparseMatrix.OfDiagonalVector(v) :> _ Matrix

    /// Create a matrix with the vector elements on the diagonal.
    let inline ofDiag2 (rows: int) (cols: int) (v: Vector<float>) = SparseMatrix.OfDiagonalVector(rows, cols, v) :> _ Matrix

    /// Create a square matrix with the array elements on the diagonal.
    let inline ofDiagArray (array: float array) = SparseMatrix.OfDiagonalArray(array) :> _ Matrix

    /// Create a matrix with the array elements on the diagonal.
    let inline ofDiagArray2 (rows: int) (cols: int) (array: float array) = SparseMatrix.OfDiagonalArray(rows, cols, array) :> _ Matrix


/// A module which implements some F# utility functions.
[<AutoOpen>]
module MatrixUtility =

    /// Construct a dense matrix from a nested list of floating point numbers.
    let inline matrix (lst: list<list<float>>) = DenseMatrix.ofRowList lst
