// HospitalsNew.cpp : Defines the entry point for the console application.
//
#include<vector>
#include<iostream>
#include<limits>
#include<queue>
#include<time.h>
#include <algorithm>
using namespace std;

struct Node
{
	int Vertex;
	int Distance;

	bool operator < (const Node& other)const
	{
		return Distance>other.Distance;
	}
};

vector< vector < Node > > vertices;
int n,m,h;
vector<int> hospitals;
bool visited[10000];
int distances[10000];

void AddEdge(int start,int end,int distance)
{
	Node node;
	node.Vertex=end;
	node.Distance=distance;
	vertices[start].push_back(node);
}

void ReadInput()
{
	cin>>n;
	cin>>m;
	cin>>h;

	int hospital;
	for(int i=0;i<h;i++)
	{
		cin>>hospital;
		hospitals.push_back(hospital-1);
	}

	int start;
	int end;
	int distance;

	vertices.resize(n);
	for(int i=0;i<m;i++)
	{
		cin>>start;
		cin>>end;
		cin>>distance;
		AddEdge(start-1,end-1,distance);
		AddEdge(end-1,start-1,distance);
	}
}

int Dijkstra(int start)
{
	for(int i=0;i<n;i++)
	{
		distances[i]=200000;
		visited[i]=false;
	}
	distances[start]=0;
	priority_queue<Node> queue;
	Node node;
	node.Vertex=start;
	node.Distance=0;
	queue.push(node);

	while(!queue.empty())
	{
		Node best=queue.top();
		visited[best.Vertex]=1;

		int bestNode=best.Vertex;
		int nextCount=vertices[bestNode].size();

		for(int i=0;i<nextCount;i++)
		{
			Node next=vertices[bestNode][i];
			int newDistance=distances[bestNode]+next.Distance;
			if(distances[next.Vertex]>newDistance)
			{
				distances[next.Vertex]=newDistance;
				Node newNode;
				newNode.Vertex=next.Vertex;
				newNode.Distance=newDistance;
				queue.push(newNode);
			}
		}

 		while(!queue.empty() && visited[queue.top().Vertex])
		{
			queue.pop();
		}
	}

	int sum=0;

	for(int i=0;i<h;i++)
	{
		distances[hospitals[i]]=0;
	}

	for(int i=0;i<n;i++)
	{
		sum+=distances[i];
	}
	return sum;

}

int main()
{
	ReadInput();
	clock_t start=clock();

	int bestSum=std::numeric_limits<int>::max();
	for(int i=0;i<h;i++)
	{
		int sum=Dijkstra(hospitals[i]);
		if(sum<bestSum)
		{
			bestSum=sum;
		}
	}

	cout<<bestSum<<endl;
	clock_t end=clock();
	cout<<((double)end-start)/CLOCKS_PER_SEC<<endl;

	return 0;
}

