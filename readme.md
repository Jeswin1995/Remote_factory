# Augmented Reality Chemical Reactor Setup

This project demonstrates how to use m2mqtt, WorldLocking tools, and Microsoft Hololens 2 to display a 3D model of a chemical reactor setup and control the same reactor using a MQTT server, ThingSpeak.

![prot P.S.I](/Images/reactor.png)

## Requirements

To use this project, you will need the following:

- Microsoft Hololens 2 device
- Unity 3D game engine (version 2019.3 or later)
- Microsoft Visual Studio 2019 or Later

### m2mqtt

m2mqtt is a lightweight MQTT client library written in C# that enables communication with MQTT brokers. It provides an easy-to-use API for sending and receiving messages, subscribing to topics, and handling different quality of service levels. This library is used in this project to establish communication between the Hololens 2 and the ThingSpeak MQTT server.

### WorldLocking tools

WorldLocking tools is a set of tools and libraries for building and deploying augmented reality applications in Unity. It provides features for mapping real-world environments, aligning virtual content with the real world, and creating shared experiences across multiple devices. This tool is used in this project to display the 3D model of the PROT PSI reactor setup in the Hololens 2.

### ThingSpeak

ThingSpeak is an Internet of Things (IoT) analytics platform that allows you to collect, analyze, and visualize data from IoT devices. It provides an MQTT broker that enables you to send and receive messages from connected devices, as well as a dashboard for visualizing and analyzing the data. This platform is used in this project to establish communication between the Hololens 2 and the chemical reactor setup.

## Setup

1. Clone this repository to your local machine.
2. Open the project in Unity.
3. In the built settings change the platform to Universal Windows Platform.
4. In the Unity editor, navigate to the "Assets/Scenes" folder and open the "SampleScene" scene.
5. Build and deploy the application to your Hololens 2 device using Visual Studio.


## Usage

1. Launch the application on your Hololens 2 device.
2. Use the Hololens 2 to scan the QR code and place the model accordingly.
3. The 3D model of the chemical reactor setup should now be displayed in the Hololens 2.
4. Use the Hololens 2 to interact with the model and control the reactor.

## Features

1. Show Internals
![Internals](/Images/Internals.png)

2. Poster
![Development](/Images/Poster.png)

3. P&ID
![Development](/Images/PID.png)

4. Slider control
![Development](/Images/Slider.png)

5. Tooltips
![Development](/Images/Tooltip.png)

## Development
![Development](/Images/Development.png)

Development cycle of the mixed reality app for hololens 2
PiXYZ plugin of unity is used to import downsized 3D models into the scene and MRTK toolkit is used to provide the necessary mixed reality interaction. Initially ARspatialpin project was used as base project for the implementation of world locking tools which was necessary for a stable 3D visualisation of the reactor. QR codes were used in the place of Spacepins and lock the world according to our needs. Scripts from mixedrealityiot project was used to eastablish connection to thingspeak broker using m2mqtt. 

Mqtt has subscribe method which allows us to get the updated data once it was published in the channel server by the device. Publish method of mqtt can be used to write values to the channel server for controlling the reactor remotely. We have to create seperate devices in thingspeak account for achieving this otherwise it might crash the connection. Each device as a unique user id and password this should be inserted into the mqtt manager script attached to the managers game object. Different field names should also be updated accordingly in the same script.

![Server](/Images/MQTTserver.png)

Mixed reality toolkit has toolbox which has lots of buttons and sliders built in. This was used as interactive elements inside the scene. Buttons should be configured inside the interactable script. Tooltips were enabled on gaze and this was achieved by editing the prefab spawner script. This edited script is in the  Test2/Assets/Scripts. Similar to this lot of other edited scripts can be found in this folder

Holographic remoting functionality in the mixed reality toolkit can be used to get a instant feedback during the development stage.

If you want to change the location of the setup according to QRcode then you have to change the coordinates of the QRCODE_1 under the markers Gameobject inside the scene. This act as the location of the QRcode inside the scene and the unity world will be set accordingly.

While building the scene in the unity, it is essential to use ARM 64 under Universal windows platform. In visual studio ARM64 should be again selected under Platform and Release  should be selected under Configuration.
## Troubleshooting

If you encounter any issues with the application, please check the following:

- Ensure that your Hololens 2 is connected to the network.
- Check that your ThingSpeak account and MQTT server are configured correctly.
- Ensure that you build the solution for ARM64

## Author
Daniel Niehaus- Supervisor

Jeswin Kannampuzha Francis- Developer


## Additional Resources


- [m2mqtt IoT project for car maintenance](https://github.com/mixedrealityiot/OBD-II_MQTT_HoloLens.git)
- [ARspatialpin project of WorldLocking tools](https://github.com/microsoft/MixedReality-WorldLockingTools-Samples.git)
 