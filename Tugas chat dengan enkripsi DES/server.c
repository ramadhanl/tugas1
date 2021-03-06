#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
 
#include <netdb.h>
#include <unistd.h>
#include <pthread.h>
 
#include <arpa/inet.h>
#include <netinet/in.h>
#include <sys/types.h>
#include <sys/socket.h>
 
#define IP "127.0.0.1"
#define PORT 8888
#define BACKLOG 10
#define CLIENTS 10
 
#define BUFFSIZE 1024
#define ALIASLEN 32
#define OPTLEN 16
 
struct PACKET {
    char option[OPTLEN]; // instruction
    char alias[ALIASLEN]; // client's alias
    char buff[BUFFSIZE]; // payload
};
 
struct THREADINFO {
    pthread_t thread_ID; // thread's pointer
    int sockfd; // socket file descriptor
    char alias[ALIASLEN]; // client's alias
};
 
struct LLNODE {
    struct THREADINFO threadinfo;
    struct LLNODE *next;
};
 
struct LLIST {
    struct LLNODE *head, *tail;
    int size;
};
 
int compare(struct THREADINFO *a, struct THREADINFO *b) {
    return a->sockfd - b->sockfd;
}
 
void list_init(struct LLIST *ll) {
    ll->head = ll->tail = NULL;
    ll->size = 0;
}
 
int list_insert(struct LLIST *ll, struct THREADINFO *thr_info) {
    if(ll->size == CLIENTS) return -1;
    if(ll->head == NULL) {
        ll->head = (struct LLNODE *)malloc(sizeof(struct LLNODE));
        ll->head->threadinfo = *thr_info;
        ll->head->next = NULL;
        ll->tail = ll->head;
    }
    else {
        ll->tail->next = (struct LLNODE *)malloc(sizeof(struct LLNODE));
        ll->tail->next->threadinfo = *thr_info;
        ll->tail->next->next = NULL;
        ll->tail = ll->tail->next;
    }
    ll->size++;
    return 0;
}
 
int list_delete(struct LLIST *ll, struct THREADINFO *thr_info) {
    struct LLNODE *curr, *temp;
    if(ll->head == NULL) return -1;
    if(compare(thr_info, &ll->head->threadinfo) == 0) {
        temp = ll->head;
        ll->head = ll->head->next;
        if(ll->head == NULL) ll->tail = ll->head;
        free(temp);
        ll->size--;
        return 0;
    }
    for(curr = ll->head; curr->next != NULL; curr = curr->next) {
        if(compare(thr_info, &curr->next->threadinfo) == 0) {
            temp = curr->next;
            if(temp == ll->tail) ll->tail = curr;
            curr->next = curr->next->next;
            free(temp);
            ll->size--;
            return 0;
        }
    }
    return -1;
}
 
void list_dump(struct LLIST *ll) {
    struct LLNODE *curr;
    struct THREADINFO *thr_info;
    printf("Connection count: %d\n", ll->size);
    for(curr = ll->head; curr != NULL; curr = curr->next) {
        thr_info = &curr->threadinfo;
        printf("[%d] %s\n", thr_info->sockfd, thr_info->alias);
    }
}
 
int sockfd, newfd;
struct THREADINFO thread_info[CLIENTS];
struct LLIST client_list;
pthread_mutex_t clientlist_mutex;
 
void *io_handler(void *param);
void *client_handler(void *fd);
 
int main(int argc, char **argv) {
    int err_ret, sin_size;
    struct sockaddr_in serv_addr, client_addr;
    pthread_t interrupt;
 
    /* initialize linked list */
    list_init(&client_list);
 
    /* initiate mutex */
    pthread_mutex_init(&clientlist_mutex, NULL);
 
    /* open a socket */
    if((sockfd = socket(AF_INET, SOCK_STREAM, 0)) == -1) {
        err_ret = errno;
        fprintf(stderr, "socket() failed...\n");
        return err_ret;
    }
 
    /* set initial values */
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_port = htons(PORT);
    serv_addr.sin_addr.s_addr = inet_addr(IP);
    memset(&(serv_addr.sin_zero), 0, 8);
 
    /* bind address with socket */
    if(bind(sockfd, (struct sockaddr *)&serv_addr, sizeof(struct sockaddr)) == -1) {
        err_ret = errno;
        fprintf(stderr, "bind() failed...\n");
        return err_ret;
    }
 
    /* start listening for connection */
    if(listen(sockfd, BACKLOG) == -1) {
        err_ret = errno;
        fprintf(stderr, "listen() failed...\n");
        return err_ret;
    }
 
    /* initiate interrupt handler for IO controlling */
    printf("Starting admin interface...\n");
    if(pthread_create(&interrupt, NULL, io_handler, NULL) != 0) {
        err_ret = errno;
        fprintf(stderr, "pthread_create() failed...\n");
        return err_ret;
    }
 
    /* keep accepting connections */
    printf("Starting socket listener...\n");
    while(1) {
        sin_size = sizeof(struct sockaddr_in);
        if((newfd = accept(sockfd, (struct sockaddr *)&client_addr, (socklen_t*)&sin_size)) == -1) {
            err_ret = errno;
            fprintf(stderr, "accept() failed...\n");
            return err_ret;
        }
        else {
            if(client_list.size == CLIENTS) {
                fprintf(stderr, "Connection full, request rejected...\n");
                continue;
            }
            printf("Connection requested received...\n");
            struct THREADINFO threadinfo;
            threadinfo.sockfd = newfd;
            strcpy(threadinfo.alias, "Anonymous");
            pthread_mutex_lock(&clientlist_mutex);
            list_insert(&client_list, &threadinfo);
            pthread_mutex_unlock(&clientlist_mutex);
            pthread_create(&threadinfo.thread_ID, NULL, client_handler, (void *)&threadinfo);
        }
    }
 
    return 0;
}
 
void *io_handler(void *param) {
    char option[OPTLEN];
    while(scanf("%s", option)==1) {
        if(!strcmp(option, "exit")) {
            /* clean up */
            printf("Terminating server...\n");
            pthread_mutex_destroy(&clientlist_mutex);
            close(sockfd);
            exit(0);
        }
        else if(!strcmp(option, "list")) {
            pthread_mutex_lock(&clientlist_mutex);
            list_dump(&client_list);
            pthread_mutex_unlock(&clientlist_mutex);
        }
        else {
            fprintf(stderr, "Unknown command: %s...\n", option);
        }
    }
    return NULL;
}
struct PACKET packet;
char pesan[300],option[16],alias[32],buff[60],targetpm[50];
void ambildata(){
	//printf("\n Panjang data : %d \n huruf ke 5 : %c\nhuruf ke 6 : %c\nhuruf ke 7 : %c\n",strlen(packet.option),packet.option[5],packet.option[6],packet.option[7]);
	int i,a,count=0,hit=0,hit2=0;
	//printf("\nIsi packet.option : %s\n",packet.option);
	strcpy(pesan,"");
	for(a=0;a<strlen(packet.option);a++){
		pesan[a]=packet.option[a];
	}
	//printf("\nIsi pesan : %s\n",pesan);
	strcpy(packet.option,"");
	strcpy(packet.alias,"");
	strcpy(packet.buff,"");
	strcpy(option,"");
	strcpy(alias,"");
	strcpy(buff,"");
	for(i=0;i<strlen(pesan);i++){
		if(pesan[i]=='$')
			count++;
		else
			{
				if(count==0){
					option[i]=pesan[i];
					//printf("\noption : %s",option);
				}
				else if(count==1){
					alias[hit]=pesan[i];
					hit++;
				}
				else if(count==2){
					buff[hit2]=pesan[i];
					hit2++;
					//printf("\nbuff : %s",buff);
				}
			}
			
	}
	strcpy(packet.option,option);
	strcpy(packet.alias,alias);
	strcpy(packet.buff,buff);
	//printf("\npacket.option : %s",packet.option);
	//printf("\npacket.alias : %s",packet.alias);
	//printf("\npacket.buff : %s\n",packet.buff);
	if(hit==0){
		strcpy(packet.alias,"Anonymous");
	}
}

void *client_handler(void *fd) {
    struct THREADINFO threadinfo = *(struct THREADINFO *)fd;
    struct LLNODE *curr;
    int bytes, sent;
    while(1) {
    	strcpy(packet.option,"");
		strcpy(packet.alias,"");
		strcpy(packet.buff,"");
		memset(&packet, 0, sizeof(struct PACKET));
		memset(&pesan[0], 0, sizeof(pesan));
		memset(&option[0], 0, sizeof(option));
		memset(&alias[0], 0, sizeof(alias));
		memset(&buff[0], 0, sizeof(buff));
		memset(&targetpm[0], 0, sizeof(targetpm));
        bytes = recv(threadinfo.sockfd, (void *)&packet, sizeof(struct PACKET), 0);
        ambildata();
		if(!bytes) {
            fprintf(stderr, "Connection lost from [%d] %s...\n", threadinfo.sockfd, threadinfo.alias);
            pthread_mutex_lock(&clientlist_mutex);
            list_delete(&client_list, &threadinfo);
            pthread_mutex_unlock(&clientlist_mutex);
            break;
        }
        printf("[%d] %s %s %s\n", threadinfo.sockfd, packet.option, packet.alias, packet.buff);
        if(!strcmp(packet.option, "name")) {
        	printf("Set alias to %s\n", packet.alias);
            pthread_mutex_lock(&clientlist_mutex);
            for(curr = client_list.head; curr != NULL; curr = curr->next) {
                if(compare(&curr->threadinfo, &threadinfo) == 0) {
                    strcpy(curr->threadinfo.alias, packet.alias);
                    strcpy(threadinfo.alias, packet.alias);
                    break;
                }
            }
            pthread_mutex_unlock(&clientlist_mutex);
        }
        else if(!strcmp(packet.option,"list")){
        	strcpy(pesan,"list$");
        	strcat(pesan,packet.alias);
        	strcat(pesan, "$");
        	//printf("\n1.Isi pesan : %s",pesan);
        	pthread_mutex_lock(&clientlist_mutex);
			for(curr = client_list.head; curr != NULL; curr = curr->next) {
				if(strcmp(curr->threadinfo.alias,packet.alias)!=0){
					strcat(pesan, "[");strcat(pesan, curr->threadinfo.alias);strcat(pesan, "]");
			    	strcat(pesan, "%");
				}
			}
			//printf("%s |%s |%s ",spacket.alias,spacket.option,spacket.buff);
			//printf("\n2.Isi pesan : %s",pesan);
			sent = send(threadinfo.sockfd, pesan, 200, 0);
            pthread_mutex_unlock(&clientlist_mutex);
        }
        else if(!strcmp(packet.option, "pmpm")) {
            int i;
            char target[ALIASLEN],isi[100];
            int count=0,hit=0;
            for(i=0;i<strlen(packet.buff);i++){
				if(packet.buff[i]=='%')
					count++;
				else
					{
						if(count==0){
							target[i]=packet.buff[i];
						}
						else if(count==1){
							isi[hit]=packet.buff[i];
							hit++;
						}
					}
					
			}
            strcpy(pesan,"pmpm$");
        	strcat(pesan,packet.alias);
        	strcat(pesan, "$");
            //for(i = 0; packet.buff[i] != ' '; i++); packet.buff[i++] = 0;
            //strcpy(target, packet.buff);
            strcat(pesan, isi);
            pthread_mutex_lock(&clientlist_mutex);
            for(curr = client_list.head; curr != NULL; curr = curr->next) {
                if(strcmp(target, curr->threadinfo.alias) == 0) {
                    struct PACKET spacket;
                    memset(&spacket, 0, sizeof(struct PACKET));
                    if(!compare(&curr->threadinfo, &threadinfo)) continue;
                    //strcpy(spacket.option, "pmpm");
                    //strcpy(spacket.alias, packet.alias);
                    //strcpy(spacket.buff, &packet.buff[i]);
                    sent = send(curr->threadinfo.sockfd, pesan, 200, 0);
                }
            }
            pthread_mutex_unlock(&clientlist_mutex);
        }
        else if(!strcmp(packet.option, "send")) {
        	pthread_mutex_lock(&clientlist_mutex);
            for(curr = client_list.head; curr != NULL; curr = curr->next) {
                struct PACKET spacket;
                memset(&spacket, 0, sizeof(struct PACKET));
                if(!compare(&curr->threadinfo, &threadinfo)) continue;
                strcpy(pesan,"send$");
	        	strcat(pesan,packet.alias);
	        	strcat(pesan, "$");
	        	strcat(pesan, packet.buff);
                //strcpy(spacket.option, "send");
                //strcpy(spacket.alias, packet.alias);
                //strcpy(spacket.buff, packet.buff);
                sent = send(curr->threadinfo.sockfd, pesan, 200, 0);
            }
            pthread_mutex_unlock(&clientlist_mutex);
        }
        else if(!strcmp(packet.option, "exit")) {
            printf("[%d] %s has disconnected...\n", threadinfo.sockfd, threadinfo.alias);
            pthread_mutex_lock(&clientlist_mutex);
            list_delete(&client_list, &threadinfo);
            pthread_mutex_unlock(&clientlist_mutex);
            break;
        }
        else {
            fprintf(stderr, "Garbage data from [%d] %s...\n", threadinfo.sockfd, threadinfo.alias);
        }
    }
 
    /* clean up */
    close(threadinfo.sockfd);
 
    return NULL;
}


