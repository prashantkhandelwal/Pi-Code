import RPi.GPIO as GPIO
from flask import Flask, render_template, request

app = Flask(__name__)

GPIO.setmode(GPIO.BCM)

GPIO.setup(18, GPIO.OUT)
GPIO.setup(23, GPIO.OUT)
GPIO.setup(24, GPIO.OUT)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/cleanup')
def cleanup():
    GPIO.cleanup()
    return render_template('index.html')

@app.route('/<light>/<state>')
def action(light, state):
    if light == "blue":
        if state == "on":
            GPIO.output(18, GPIO.HIGH)

        if state == "off":
            GPIO.output(18, GPIO.LOW)

    if light == "red":
        if state == "on":
            GPIO.output(23, GPIO.HIGH)
        if state == "off":
            GPIO.output(23, GPIO.LOW)

    if light == "green":
        if state == "on":
            GPIO.output(24, GPIO.HIGH)
            
        if state == "off":
            GPIO.output(24, GPIO.LOW)

    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
