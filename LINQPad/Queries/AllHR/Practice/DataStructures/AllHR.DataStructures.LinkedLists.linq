<Query Kind="Program" />

//https://www.youtube.com/user/mycodeschool
void Main()
{
	//MergeListMain();
	//RemoveDuplicatesMain();
	//HasCycleMain();
	//SortedInsertMain();
	ReverseDoublyLinkedListMain();
}

void ReverseDoublyLinkedListMain()
{
	Node node3 = new Node(2,null);
	Node node2 = new Node(4,node3);
	Node node1 = new Node(6,node2);
	node3.prev = node2; node2.prev = node1;
	//Console.WriteLine(node1);
	Node h = ReverseDoublyLinkedList(node1);
	//Console.WriteLine(h);
}

Node ReverseDoublyLinkedList(Node head)
{
	Node h = head;
    while(head != null) 
    {
        head.prev = head.next;
        head = head.next;
    }
	Console.WriteLine(h);
    Node prev = null;
    Node cur = h;
	head = h;
	Node tail = null;
    while(h != null)
    {
		prev = cur;
		cur = cur.next;
		cur.next = prev;
		if(h.prev == null) tail = cur;
		h = h.prev;
    }
	Console.WriteLine(tail);
    return h;
}

void SortedInsertMain()
{
	//1 4 2 3 7 6 9 10
	Node head = SortedInsert(null,1);
	head = SortedInsert(head,4);
	head = SortedInsert(head,2);
//	head = SortedInsert(head,3);
//	head = SortedInsert(head,7);
//	head = SortedInsert(head,6);
//	head = SortedInsert(head,9);
//	head = SortedInsert(head,10);
	Console.WriteLine(head);


//	2 1 4 3
//	Node head = SortedInsert(null,2);
//	head = SortedInsert(head,1);
//	head = SortedInsert(head,4);
//	head = SortedInsert(head,3);
//	Console.WriteLine(head);
}

Node SortedInsert(Node head,int data) {
    Node newNode = new Node();
    newNode.data = data;
    if(head == null) { head = newNode; return head; } 
    Node h = head;
    while(h.next != null && data > h.next.data)
    {
        h = h.next;
    }
	if(h.next == null) { h.next = newNode; newNode.prev = h; } 
    else if(h == head) { head = newNode; head.next = h; h.prev = head; } 
    else { Node t = h.next; h.next = newNode; newNode.prev = h; newNode.next = t; t.prev = newNode; } 
    return head; 
}

void MergeSortedLinkedLists()
{
//    MergeSorted(Node a,Node b)
//        if a is NULL and b is NULL
//            return NULL
//        if a is NULL
//            return b
//        if b is NULL
//            return a
//
//        Node c //Combined List
//        if((*a).value<(*b).value)
//            c=a
//            (*c).next=MergeSorted((*a).next,b)
//        else
//            c=b
//            (*c).next=MergeSorted(a,(*b).next)      
//        return c
}

void HasCycleMain()
{
	Node node4 = new Node(4,null);
	Node node3 = new Node(3,node4);
	Node node2 = new Node(2,node3);
	Node node1 = new Node(1,node2);
	//Node nodeA = new Node(1, new Node(2, new Node(3, node4)));
	node4.next = node2;
	Console.WriteLine(HasCycle(node1));
}

bool HasCycle(Node head) {
    if (head == null){
        return false;
    }

    Node slow = head;
    Node fast = head;

    while (fast != null && fast.next != null){
		Console.WriteLine(slow);
		Console.WriteLine(fast);
        slow = slow.next;
        fast = fast.next.next;

        if (slow == fast){
            return true;
        }
    }
    return false;
}

private void RemoveDuplicatesMain()
{
	Node nodeA = new Node(1, new Node(1, new Node(1, new Node(1, null))));
	//Console.WriteLine(nodeA);
	Node head = RemoveDuplicates(nodeA);
	//Console.WriteLine(head);
}

Node RemoveDuplicates(Node head) {
  // This is a "method-only" submission. 
  // You only need to complete this method. 
    Node h = head;
    while(head != null)
    {
		//Console.WriteLine(head);
        if(head.next != null && head.data == head.next.data)
        {
            if(head.next.next != null)
			{
                head.next = head.next.next;
				continue;
			}
            else 
                head.next = null;
				
        }
		//Console.WriteLine(head);
        head = head.next;
    }
	//Console.WriteLine(h);
    return h;
}

private static void MergeListMain()
{
	Node nodeA = new Node(1, new Node(3, new Node(5, new Node(6, null))));
	Node nodeB = new Node(2, new Node(4, new Node(7, null)));

	Console.WriteLine(nodeA);
	Console.WriteLine(nodeB);
	Node head = MergeLists(nodeA, nodeB);
	Console.WriteLine(head);
}

private static Node MergeLists(Node headA, Node headB) {
     // This is a "method-only" submission. 
     // You only need to complete this method 
    if(headA == null && headB == null) return null;
    if(headA == null) return headB;
    if(headB == null) return headA;
    
    Node head = headA.data < headB.data ? headA : headB;
	
    while(headA.next != null && headB.next != null)
    {
        if(headA.data < headB.data)
		{
          	head = headA;
		}
		else head = headB;
		
		headA = headA.next;
		headB = headB.next;
	}
    return head;
}

private static int GetNodeValue(Node node, int position)
{
	int nodesCount = 0;
	Node head = node;
	while(node != null)
	{
		nodesCount++;
		node = node.next;
	}
	//Console.WriteLine(nodesCount);
	int c = nodesCount - position;
	while(--c > 0){ head = head.next; }
	//Console.WriteLine(head.Data);
	return head.data;
}

private static void ReverseMain()
{
	Node node4 = new Node(6, null);
	Node node3 = new Node(5, node4);
	Node node2 = new Node(3, node3);
	Node node1 = new Node(1, node2);
	/*
	Console.WriteLine(GetNodeValue(node1, 0));
	Console.WriteLine(GetNodeValue(node1, 1));
	Console.WriteLine(GetNodeValue(node1, 2));
	Console.WriteLine(GetNodeValue(node1, 3));
	Console.WriteLine(GetNodeValue(node1, 4));
	Console.WriteLine(GetNodeValue(node1, 5));
	Console.WriteLine(GetNodeValue(node1, 7));
	*/
	/* Reverse Linked List 1
	Node node = node1;
	while(node != null)
	{
		Console.Write($"{node.Data} ");
		node = node.Next;
	}
	Console.WriteLine();
	Node head = new Node(0, null);
	node = ReverseLinkedList(node1, ref head);
	node.Next = null;
	while(head != null)
	{
		Console.Write($"{head.Data} ");
		head = head.Next;
	}
	//
	Node node = node1;
	while(node != null)
	{
		Console.Write($"{node.data} ");
		node = node.next;
	}
	Console.WriteLine();
	node = Reverse(node1);
	Node n1 = node;
	while(node != null)
	{
		Console.Write($"{node.data} ");
		node = node.next;
	}
	Console.WriteLine();
	node = ReverseLinkedList(n1);
	while(node != null)
	{
		Console.Write($"{node.data} ");
		node = node.next;
	}
	**/
}

// Define other methods and classes here
private static Node ReverseLinkedList(Node head)
{
	//Console.WriteLine(head);
	if(head.next == null) { return head; }
	Node newHead = ReverseLinkedList(head.next);
	//Console.WriteLine(head);
	head.next.next = head;
	head = head.next;
	head.next.next = null;
	//head.Next = null;
	//Console.WriteLine(head);
	//head.Next = head;
	//Console.WriteLine(n);
	return newHead;
}

Node Reverse(Node head) {
	/* We have two conditions in this if statement.
	  This first condition immediately returns null
	  when the list is null. The second condition returns
	  the final node in the list. That final node is sent
	  into the "remaining" Node below.
	-----------------------------------------------------*/
	if (head == null || head.next == null) {  
	    return head;  
	}
	/* When the recursion creates the stack for A -> B -> C
	   (RevA(RevB(RevC()))) it will stop at the last node and
	   the recursion will end, beginning the unraveling of the
	   nested functions from the inside, out. 
	-----------------------------------------------------*/
	Node remaining = Reverse(head.next);
	/* Now we have the "remaining" node returned and accessible
	   to the node prior. This remaining node will be returned
	   by each function as the recursive stack unravels.
	
	   Assigning head to head.next.next where A is the head
	   and B is after A, (A -> B), would set B's pointer to A,
	   reversing their direction to be A <- B.
	-----------------------------------------------------*/
	head.next.next = head; 
	/* Now that those two elements are reversed, we need to set
	the pointer of the new tail-node to null.
	-----------------------------------------------------*/
	head.next = null;  
	/* Now we return remaining so that remaining is always
	   reassigned to itself and is eventually returned by the
	   first function call.
	-----------------------------------------------------*/
	return remaining; 
}

private static Node ReverseLinkedList(Node node, ref Node head)
{
	if(node.next == null) { head = node; return node; }
	Node n = ReverseLinkedList(node.next, ref head);
	n.next = node;
	//Console.WriteLine(n);
	return node;
}

private static Node ReverseLinkedListHREditorial(Node node)
{
	Node cur = node;
	Node prev = null;
	Node next = node.next;
	int count = 0;
	while(node != null)
	{
		
	}
	
	return node;
}



///****************************/////
public class LinkedList
{
	Node [] list;
	static int indexer = 0;
	public LinkedList()
	{
		list = new Node[10];
	}
	public LinkedList(int capacity)
	{
		list = new Node[capacity];
	}
	
	public void Add(Node node)
	{
		list[indexer++] = node;
	}
}
public class Node{

	public Node()
	{
		this.data = 0;
		this.next = null;
		this.prev = null;
	}

	public Node(int data, Node next)
	{
		this.data = data;
		this.next = next;
		this.prev = null;
	}

	public Node(int data, Node next, Node prev)
	{
		this.data = data;
		this.next = next;
		this.prev = prev;
	}

	public int data { get; set; }
	public Node next { get; set; }
	public Node prev { get; set; }
}
