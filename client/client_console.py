import Client
import os
import hashlib

global current_room
current_room =""
global session_key


def register():
    global username 
    username = input("Masukkan Username :")
    global password 
    password = input("Masukkan password :")
    cl.send({'flag':'REG','sender':username, 'receiver':'server' ,'content': {'username':username,'password':password},'type':'TEXT'})
    balasan = cl.receive()
    print(balasan['content'])
    input("Press Enter to continue...")
    mainMenu()

def login():
    global username 
    username = input("Masukkan Username :")
    global password 
    password = input("Masukkan password :")
    cl.send({'flag':'LOGIN','sender': username ,'receiver':'server','content':{'username':username,'password':password},'type':'TEXT'})
    login_data = cl.receive()
    if login_data['code']=='LOGIN_OK':
        print(login_data['content'])
        cl.username=username
        cl.password=password
        global session_key
        #session_key= hashlib.sha256(str(cl.username).encode('utf-8')).hexdigest();
        session_key=login_data['session_key']
        print();
    else:
        print(login_data['content'])
    input("Press Enter to continue...")
    mainMenu()



def req_online():
        global session_key
        cl.send({'flag':'GET_LIST_ONLINE', 'sender':cl.username,'receiver':'server', 'type':'text','session_key':session_key})
        result_data = cl.receive()
        print(result_data['content'])
        input("Press Enter to continue...")
        mainMenu()

def send_chat():
        global current_room
        global session_key
        receiver=nput("masukan nama user: ")
        message =input("masukan pesan : ")
        cl.send({'flag':'SEND', 'sender':cl.username , 'receiver':receiver , 'content':message , 'type':'TEXT','session_key':session_key });
        result_data = cl.receive()
        print(result_data['content'])
        input("Press Enter to continue...")
        mainMenu()

def quit_room():
        global current_room
        global session_key
        cl.send({'flag':'QUIT_ROOM','sender':cl.username,'receiver':'server','content':current_room,'type':'TEXT','session_key':session_key})
        current_room =""
        input("Press Enter to continue...")
        mainMenu()
def logout():
        global session_key
        cl.send({'flag':'LOGOUT' , "sender":cl.username , "RECEIVER":"server" , 'content':cl.username,"TYPE":"TEXT",'session_key':session_key });
        result_data = cl.receive()
        print(result_data['content'])
        exit()

def mainMenu():
    os.system('cls')
    global current_room
    if not cl.username=="" :
        print("terlogin sebagai : " +cl.username)  
    
    print("selamat datang silahkan pilih perintah yang ingin anda lakukan")
    print("1.Register")
    print("2.Login")
    print("3.Send Chat")
    print("4.Request list online")
    print("5.logout")

    choice = input("Masukkan pilihan anda : ")
    options = { 1 : register,
                2 : login,
                3 : send_chat,
                4 : req_online,
                5 : logout
                
               }
    options[int(choice)]()





cl = Client.client()
cl.connect()
mainMenu()



