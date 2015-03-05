#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

int change(int *d,int k,int n,int *S,int *C){
	int min,coin;
	C[0]=0;
	for(int p=1;p<=n;p++){
		min=99999;
		for(int i=1;i<=k;i++){
			if(d[i]<=p){
				if(1+C[p-d[i]]<min)
				min = 1+C[p-d[i]];
				coin = i;
			}
		}
		C[p]=min;
		S[p]=coin;
	}
	
}

void makechange(int *S,int *d,int n){
	while(n>0){
		cout<<d[S[n]]<<" ";
		n=n-d[S[n]];
	}
}
int main(){
	int S[400],d[400], k, n,C[400],i;
	cin >> k ;
	for (i=1; i<=k ; i++)
		cin >> d[i];
	cin >> n;
	change(d,k,n,S,C);
	cout<<"Jumlah koin yang digunakan : "<<C[n]<<endl;
	cout<<"Koin yang dipakai : ";
	makechange(S,d,n);
	cout<<endl;
	
}
