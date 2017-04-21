<Query Kind="Program" />

//https://www.codechef.com/viewsolution/2536548
//https://www.codechef.com/PRCN2013/problems/PC04
//https://www.codeproject.com/Tips/862988/Find-the-Intersection-Point-of-Two-Line-Segments
//http://stackoverflow.com/questions/563198/how-do-you-detect-where-two-line-segments-intersect
//http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
//https://math.stackexchange.com/questions/891803/how-to-test-whether-a-set-of-four-points-can-form-a-parallelogram
void Main()
{
	SplitPlane();
}

// Define other methods and classes here
void SplitPlane()
{
	int q = Convert.ToInt32("4");
	int [] N = { 5, 5, 5, 5 };
	string [][] L = {
							new String[] { "1 3 1 4", "2 0 2 3", "4 2 4 3", "0 1 3 1", "0 2 3 2" }
						,	new String[] { "1 2 1 4", "2 0 2 3", "4 2 4 3", "0 1 3 1", "0 2 3 2" }
						,	new String[] { "-1 -2 -1 2", "1 -2 1 2", "2 -1 -2 -1", "2 1 -2 1", "-1 -2 -1 3" }
						,	new String[] { "-2 -2 -2 2", "1 -2 1 2", "2 -1 -2 -1", "2 1 -2 1", "-1 -2 -1 3" }
						//,	new String[] { "-1 -2 -1 2", "1 -2 1 2", "2 -1 -2 -1", "2 1 -2 1", "-1 -2 -1 3" }
					};
    for(int a0 = 0; a0 < q; a0++)
	{
        int n = N[a0];
		List<Tuple<Tuple<int,int>,Tuple<int,int>>> horizontals = new List<Tuple<Tuple<int,int>,Tuple<int,int>>>();
		List<Tuple<Tuple<int,int>,Tuple<int,int>>> verticals = new List<Tuple<Tuple<int,int>,Tuple<int,int>>>();
        for(int a1 = 0; a1 < n; a1++)
		{
            int [] co = Array.ConvertAll(L[a0][a1].Split(' '), Int32.Parse);
			int y1 = co[0], x1 = co[1], y2 = co[2], x2 = co[3];
			var point1 = new Tuple<int,int>(x1, y1);
			var point2 = new Tuple<int,int>(x2, y2);
			if( y1 == y2) { horizontals.Add(new Tuple<Tuple<int,int>,Tuple<int,int>>(point1,point2)); }
			else { verticals.Add(new Tuple<Tuple<int,int>,Tuple<int,int>>(point1,point2)); }
		}
		Console.WriteLine($"Horizontals:{horizontals.Count} Verticals:{verticals.Count}");
		//Console.WriteLine(horizontals);
		//Console.WriteLine(verticals);
		
		List<Tuple<int,int>> intersections = new List<Tuple<int,int>>();
		for(int h = 0; h < horizontals.Count; h++)
		{
			var horiLine = horizontals[h];
			Vector hSP = new Vector(horiLine.Item1.Item1,horiLine.Item1.Item2);
			Vector hEP = new Vector(horiLine.Item2.Item1,horiLine.Item2.Item2);
			for(int v = 0; v < verticals.Count; v++)
			{
				var vertLine = verticals[v];
				Vector vSP = new Vector(vertLine.Item1.Item1,vertLine.Item1.Item2);
				Vector vEP = new Vector(vertLine.Item2.Item1,vertLine.Item2.Item2);
				Vector intersection;
				
    			if(LineSegementsIntersect(hSP,hEP,vSP,vEP, out intersection))
					intersections.Add(new Tuple<int,int>((int)intersection.X, (int)intersection.Y));
				
			}
		}
		//Console.WriteLine(intersections);
		int count = 1;
		HashSet<Tuple<int,int>> processed = new HashSet<Tuple<int,int>>();
		for(int i = 1; i < intersections.Count; i++)
		{
			var p1 = intersections[i-1];
			var p2 = intersections[i];
			for(int j = i + 1; j < intersections.Count; j++)
			{
				var p3 = intersections[j-1];
				var p4 = intersections[j];
				if(!(	
						processed.Contains(p1) 
						&& processed.Contains(p2) 
						&& processed.Contains(p3) 
						&& processed.Contains(p4)
					) 
					&& IsParallelogram(p1,p2,p3,p4))
				{
					count++;
					processed.Add(p1);
					processed.Add(p2);
					processed.Add(p3);
					processed.Add(p4);
				}
			}
		}
		Console.WriteLine(count);
    }
}

bool IsParallelogram(Tuple<int,int> p1, Tuple<int,int> p2, Tuple<int,int> p3, Tuple<int,int> p4)
{
	if(Math.Abs(p1.Item1 - p2.Item1) == Math.Abs(p3.Item1 - p4.Item1) && Math.Abs(p1.Item2 - p2.Item2) == Math.Abs(p3.Item2 - p4.Item2))
	{	
		/*
		Console.WriteLine($"p1.Item1:{p1.Item1}	p2.Item1:{p2.Item1} Diff:{Math.Abs(p1.Item1 - p2.Item1)}");
		Console.WriteLine($"p3.Item1:{p3.Item1}	p4.Item1:{p4.Item1} Diff:{Math.Abs(p3.Item1 - p4.Item1)}");
		Console.WriteLine($"p1.Item2:{p1.Item2}	p2.Item2:{p2.Item2} Diff:{Math.Abs(p1.Item2 - p2.Item2)}");
		Console.WriteLine($"p3.Item2:{p3.Item2}	p4.Item2:{p4.Item2} Diff:{Math.Abs(p3.Item2 - p4.Item2)}");
		*/
		return true;
	}
	if(Math.Abs(p1.Item1 - p3.Item1) == Math.Abs(p2.Item1 - p4.Item1) && Math.Abs(p1.Item2 - p3.Item2) == Math.Abs(p2.Item2 - p4.Item2))
	{	
		/*
		Console.WriteLine($"p1.Item1:{p1.Item1}	p3.Item1:{p3.Item1} Diff:{Math.Abs(p1.Item1 - p3.Item1)}");
		Console.WriteLine($"p2.Item1:{p2.Item1}	p4.Item1:{p4.Item1} Diff:{Math.Abs(p2.Item1 - p4.Item1)}");
		Console.WriteLine($"p1.Item2:{p1.Item2}	p3.Item2:{p3.Item2} Diff:{Math.Abs(p1.Item2 - p3.Item2)}");
		Console.WriteLine($"p2.Item2:{p2.Item2}	p4.Item2:{p4.Item2} Diff:{Math.Abs(p2.Item2 - p4.Item2)}");
		*/
		return true;
	}
    return false;
}

// Define other methods and classes here

public class Vector
{
    public double X;
    public double Y;

    // Constructors.
    public Vector(double x, double y) { X = x; Y = y; }
    public Vector() : this(double.NaN, double.NaN) {}

    public static Vector operator -(Vector v, Vector w)
    {
        return new Vector(v.X - w.X, v.Y - w.Y);
    }

    public static Vector operator +(Vector v, Vector w)
    {
        return new Vector(v.X + w.X, v.Y + w.Y);
    }

    public static double operator *(Vector v, Vector w)
    {
        return v.X * w.X + v.Y * w.Y;
    }

    public static Vector operator *(Vector v, double mult)
    {
        return new Vector(v.X * mult, v.Y * mult);
    }

    public static Vector operator *(double mult, Vector v)
    {
        return new Vector(v.X * mult, v.Y * mult);
    }

    public double Cross(Vector v)
    {
        return X * v.Y - Y * v.X;
    }

    public override bool Equals(object obj)
    {
        var v = (Vector)obj;
        return (X - v.X).IsZero() && (Y - v.Y).IsZero();
    }
    
	public override int GetHashCode()
    {
		return base.GetHashCode();
    }
}

public static bool LineSegementsIntersect(Vector p, Vector p2, Vector q, Vector q2, 
    out Vector intersection, bool considerCollinearOverlapAsIntersect = false)
{
    intersection = new Vector();

    var r = p2 - p;
    var s = q2 - q;
    var rxs = r.Cross(s);
    var qpxr = (q - p).Cross(r);

    // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
    if (rxs.IsZero() && qpxr.IsZero())
    {
        // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
        // then the two lines are overlapping,
        if (considerCollinearOverlapAsIntersect)
            if ((0 <= (q - p)*r && (q - p)*r <= r*r) || (0 <= (p - q)*s && (p - q)*s <= s*s))
                return true;

        // 2. If neither 0 <= (q - p) * r = r * r nor 0 <= (p - q) * s <= s * s
        // then the two lines are collinear but disjoint.
        // No need to implement this expression, as it follows from the expression above.
        return false;
    }

    // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
    if (rxs.IsZero() && !qpxr.IsZero())
        return false;

    // t = (q - p) x s / (r x s)
    var t = (q - p).Cross(s)/rxs;

    // u = (q - p) x r / (r x s)

    var u = (q - p).Cross(r)/rxs;

    // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
    // the two line segments meet at the point p + t r = q + u s.
    if (!rxs.IsZero() && (0 <= t && t <= 1) && (0 <= u && u <= 1))
    {
        // We can calculate the intersection point using either t or u.
        intersection = p + t*r;

        // An intersection was found.
        return true;
    }

    // 5. Otherwise, the two line segments are not parallel but do not intersect.
    return false;
}

public static class Extensions
{
    private const double Epsilon = 1e-10;

    public static bool IsZero(this double d)
    {
        return Math.Abs(d) < Epsilon;
    }
}