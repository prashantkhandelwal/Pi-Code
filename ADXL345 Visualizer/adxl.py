#from adxl345 import ADXL345
import Adafruit_ADXL345
import socket

HOST = "192.168.1.8"
PORT = 50007

accel = Adafruit_ADXL345.ADXL345()
#accel.set_range(Adafruit_ADXL345.ADXL345_RANGE_8_G)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((HOST, PORT))
s.listen(1)
conn, addr = s.accept()

while 1:
    data = conn.recv(1024)

    if data.strip() == "adxl":
        x, y, z = accel.read()
        data = 'X:' + str(x) + '|Y:' + str(y) + '|Z:' + str(z)
        conn.send(data)
    
#    print '\n------------------'
