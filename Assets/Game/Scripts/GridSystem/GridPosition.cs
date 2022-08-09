using System;

public struct GridPosition : IEquatable<GridPosition> {

    public override bool Equals(object obj) {
        return obj is GridPosition gridPosition && Equals(gridPosition);
    }

    public override int GetHashCode() {
        unchecked {
            return (x * 397) ^ z;
        }
    }


    public int x;
    public int z;

    public GridPosition(int x, int z) {
        this.x = x;
        this.z = z;
    }


    public override string ToString() {
        return $"x:{x}, z:{z}";
    }

    public bool Equals(GridPosition other) {
        return this == other;
    }

    public static bool operator ==(GridPosition operand1, GridPosition operand2) {
        return operand1.x == operand2.x && operand1.z == operand2.z;
    }

    public static bool operator !=(GridPosition operand1, GridPosition operand2) {
        return !(operand1 == operand2);
    }
}
