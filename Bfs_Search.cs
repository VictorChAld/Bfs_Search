using System;
using System.Collections.Generic;
using System.Text;

public class Bfs_Search
{
	public List<int> values = new List<int>();
	public class Nodo
	{
		public int value;
		public Nodo left;
		public Nodo right;

		public Nodo(int valor)
		{
			value = valor;
			left = right = null;
		}
	}

	Nodo root = null;

	public void Insert(Nodo data)
	{
		root = Insert_Recursive(root, data);
	}

	private Nodo Insert_Recursive(Nodo root, Nodo data)
	{
		int valor = data.value;
		if (root == null)
		{
			return data;
		}

		if (valor < root.value)
		{
			root.left = Insert_Recursive(root.left, data);
		}
		else
		{
			root.right = Insert_Recursive(root.right, data);
		}

		return root;
	}

	public bool Display(List<int> compare)
	{		

		bool res = Display_Recursive(root, values, compare);
		Console.WriteLine($"{string.Join(",", values.ToArray())}");
		if (compare != null && values.Count != compare.Count) { return false; }
		return res;
	}

	private bool Display_Recursive(Nodo data, List<int> values, List<int> compare)
	{
		if (data != null) //Aquí es donde de hecho se está haciendo el Inorder traversal
		{
			if (!Display_Recursive(data.left, values, compare)) { return false; }
			values.Add(data.value);
			if (compare != null && compare.Count > 0 && compare[values.Count - 1] != values[values.Count - 1]) { return false; }
			if (!Display_Recursive(data.right, values, compare)) { return false; }						
		}
		return true;
	}	
}

