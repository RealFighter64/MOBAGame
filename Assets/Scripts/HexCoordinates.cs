using UnityEngine;

public struct HexCoordinates
{
	[SerializeField]
	private int x, z;

	public int X { get { return x; } }

	public int Z { get { return z; } }

	public int Y { get { return -X - Z; } }

	public HexCoordinates (int x, int z)
	{
		this.x = x;
		this.z = z;
	}

	public static HexCoordinates FromOffsetCoordinates (int x, int z) {
		return new HexCoordinates(x - z / 2, z);
	}

	public override string ToString () {
		return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
	}

	public string ToStringOnSeparateLines () {
		return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
	}

	public static HexCoordinates FromPosition (Vector3 position) {
		float x = position.x / (HexMetrics.innerRadius * 2f);
		float y = -x;
		float offset = position.z / (HexMetrics.outerRadius * 3f);
		x -= offset;
		y -= offset;
		int iX = Mathf.RoundToInt(x);
		int iY = Mathf.RoundToInt(y);
		int iZ = Mathf.RoundToInt(-x -y);

		if (iX + iY + iZ != 0) {
			float dX = Mathf.Abs(x - iX);
			float dY = Mathf.Abs(y - iY);
			float dZ = Mathf.Abs(-x -y - iZ);

			if (dX > dY && dX > dZ) {
				iX = -iY - iZ;
			}
			else if (dZ > dY) {
				iZ = -iX - iY;
			}
		}

		return new HexCoordinates(iX, iZ);
	}

	public Vector3 CentreToWorldPosition () {
		Vector3 position = new Vector3 (0, 0, 0);
		position.x = (x+z*0.5f-z/2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);
		return position;
	}

	public Vector3[] GetWorldVertices() {
		Vector3[] verts = new Vector3[7];
		for (int i = 0; i < HexMetrics.corners.Length; i++) {
			verts [i] = CentreToWorldPosition () + HexMetrics.corners [i];
		}
		return verts;
	}

	public static bool operator == (HexCoordinates h1, HexCoordinates h2) {
		if (h1.X == h2.X && h1.Y == h2.Y) {
			return true;
		} else {
			return false;
		}
	}

	public static bool operator != (HexCoordinates h1, HexCoordinates h2) {
		if (h1.X == h2.X && h1.Y == h2.Y) {
			return false;
		} else {
			return true;
		}
	}

	public override bool Equals(Object o) {
		try {
			return (bool) (this == (HexCoordinates) o);
		} catch {
			return false;
		}
	}
}

