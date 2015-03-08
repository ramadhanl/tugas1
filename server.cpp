#include <stdio.h>
#include <sys/types.h>
#include <arpa/inet.h>
#include <sys/socket.h>
#include <errno.h>
#include <string.h>
#include <stdlib.h>

void main ()
{
	int sockfd, sockcli;
	int retval,clisize;
	struct sockaddr_in servaddr, cliaddr;
	
	sockfd = socket(AF_INET,SOCK_STREAM, IPPROTO_TCP);
	servaddr.sin_family = AF_INET;
	servaddr.sin_port = htons(6060);
	servaddr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	retval = bind(sockfd,(struct sockaddr *)&servaddr,sizeof(servaddr));
	
	if (retval < 0){
		perror(strerror(errno));
		exit(-1);
	}
	printf ("Server mengikat port 6060\n");
	retval = listen(sockfd, 5);
	printf ("Server menunggu panggilan......\n");
	
	bzero(&cliaddr, sizeof(cliaddr));
	clisize = 0;
	sockcli = accept(sockfd,(struct sockaddr*)&cliaddr, &clisize);
	printf ("Ada Client masuk dari %s\n", inet_ntoa(cliaddr.sin_addr));
	if (sockcli < 0){
		perror(strerror(errno));
		exit(-1);
	}
	//baca tulis disini
	char msg[30], buf[255];
	read(sockcli,buf,sizeof(buf)-1);
	buf[strlen(buf)]='\0';
	strcpy(msg,buf);	
	retval = write(sockcli,msg,strlen(msg));
	
	printf ("Selesai Kirim Pesan");
	close(sockcli);
	close(sockfd);
	
}

