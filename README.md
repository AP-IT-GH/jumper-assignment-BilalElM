By: Bilal El Makrini and Adrian Moniakowski

# Jumper Assignment Tutorial
This is a tutorial for a Jumper exercise where a ML-Agent will learn how to jump over a Sphere obstacle and collect a coin Sphere. 

![image](https://user-images.githubusercontent.com/78807955/233431475-94e47708-b660-46c1-a77e-5660192fc315.png)

# Overview
This tutorial will tell you how to:
  
  1. Create the needed environment for the agent.
  2. Implement the needed scripts for the agent and objects.
  3. Allocate the scipts to the agent and needed scripts.

Before you start with this you should have a basic understand of Unity and ML-Agents work.

# Setting up your project
The very first thing u need to do so create your project so u are able to create the environment. To do that u need to open you Unity Hub and proceed to create a new projet and select "3D Core" as your template. Afterwards press on create project, it will take a minute or two create it.

![image](https://user-images.githubusercontent.com/78807955/233432831-3c5b4737-f78d-4893-be7e-be5ba675a04f.png)

Before you can start making your environment u have to install a certain package so that u can train your ML-Agent. Go to to the Window in the taskbar of you Unity project and click on Packet Manager. Afterwards u need to find the ML Agents package. Install it and then u are ready to create your own environment.

![image](https://user-images.githubusercontent.com/78807955/233433513-060fc98f-7c0b-41d5-9431-6922765a95cf.png)

# Creating Environment

This part will tell you what u need for the scene to be able to train your agent. The needed objects are: a plane, a cube and 2 spheres.

### Plane
The plane is going to be the floor where the cube (agent) is going to stand on when trying to avoid the obstacles and get the coins.
To add a plane u need to go to GameObject section and further select 3D Object. In there u can see all the basic shapes u can use in Unity. Select plane and place it. U can name it Floor to manage all the GameObjects easier later on. The position doesn't have to be exactly the same as on the screenshot below, just bare in mind that u might need to change some of the values in the scripts that will come later on.

![image](https://user-images.githubusercontent.com/78807955/233435319-ec710328-3554-4779-b7ab-c51d608df338.png)

### Cube
The cube is going to be the agent that is going to learn. It is important to make sure that the cube has a box collider around it and is trigger off, so the cube can collide with the coming spheres but also so it doesn't go throught the floor. Aside the collider it also needs a Ridigbody so the cube has the physics and just doesn't float in the air when jumping but falls down. U also need to several implemented Unity scripts. Firstly its the Decision Requester, secondly Ray Perception Sensor 3D which adds rays to the cube so it can see what it happening and lastly Behavior Parameters which are needed so the agent can do learning.

![image](https://user-images.githubusercontent.com/78807955/233436600-ff16b32c-2505-4650-967d-8b570573aea3.png)

### Sphere
Last but not least the spheres. U need to make 2 prefabs of those. 1st prefab is going to be acting as the obstacle sphere, that the agent has to jump over and the 2nd sphere that acts as the coin that the agent has to collide with. The same as for the cube u need to add a Rigidbody as well as the sphere collider. For the Rigidbody u have to tick off the gravity just it can fly in the air without it falling down. Lastly but most importantly u need to change the tags for the each of the spheres. For the coin u need to change the tag to "Coin" and for the obstacle change it to "Obstacle".

![image](https://user-images.githubusercontent.com/78807955/233438333-c09ae268-66f6-45dd-aa4d-12c199879d2d.png)

![image](https://user-images.githubusercontent.com/78807955/233438363-7a3b7b7b-61f1-4e07-a4b9-5567f13ef5ed.png)

If u want to change the colors of all the added GameObjects u can add materials to your project and select which ones u want to use for each of the objects.

# Scripts
For this project u need to create 3 scripts: AgentMovement, Spawner and Target.

### AgentMovement

[AgentMovement.txt](https://github.com/AP-IT-GH/jumper-assignment-BilalElM/files/11289092/AgentMovement.txt)

This script is responsible for the movement of the cube.

![image](https://user-images.githubusercontent.com/78807955/233449349-87b45a40-f21e-4242-bdbf-10a3d52162e5.png)

These are the packets u need for the script to work. The System packets are standard and are needed for the script to work in Unity. The MLAgents packets are needed for the agent to be able to learn.

![image](https://user-images.githubusercontent.com/78807955/233450201-62187c1f-d175-4673-818b-8f3af01ce1d5.png)

The public Transforms are used there so we can allocate the obstacle and coin so they work like they are inteded to. OnEpisodeBegin method is there so whenever the episode ends the cube goes back to the starting position (this is where the position of your cube on the scene matters).

![image](https://user-images.githubusercontent.com/78807955/233451527-6bd35877-fe5a-45e1-89ff-0baa11ac6c1b.png)

The collect observation is needed so the cube can use the rays added so it can see which obstacle is coming in.

![image](https://user-images.githubusercontent.com/78807955/233452698-b2fb48ac-8c3d-490b-93d3-52335d294a99.png)

Next u add the public floats that are there for the speed of your jump and also what is the max jump height of the agent. The OnActionReceived is there so the cube can jump. It uses the before made floats to say how high and how fast the jump is. Besides that it also gets a little bit of a reward whenever it jumps and if the cube goes off the floor the episode also ends.

![image](https://user-images.githubusercontent.com/78807955/233453698-c4f9caeb-ee24-4726-8a4a-29c5766adcbb.png)

The heuristics are the just in case u want to run your project and test if it behaves like inteded.

![image](https://user-images.githubusercontent.com/78807955/233453886-64db96cf-7874-444f-a1d8-f57b8b807de5.png)

Lastly OnCollisionEnter is used to check if the cube collided with the obstacle or coin. If it collides with the obstacle it receives negative reward and also it ends the episode. If it collides with the coin it gives positive reward. Both If functions destroy the object on collision and print it in the console which one was collided.

### Spawner

[Spawner.txt](https://github.com/AP-IT-GH/jumper-assignment-BilalElM/files/11289446/Spawner.txt)

This script is used to spawn the obstacles/coins.

![image](https://user-images.githubusercontent.com/78807955/233457899-436b3afc-b8e8-4009-8ca1-4b2e8fa9d149.png)

The script uses a random number between 1 and 6 to decide which of the spheres is going to spawn. The counter is used so the spawn rate of the spheres isn't too overwhelming for the cube and has enough time to react and jump in the right momement.

### Target

[Target.txt](https://github.com/AP-IT-GH/jumper-assignment-BilalElM/files/11289465/Target.txt)

![image](https://user-images.githubusercontent.com/78807955/233460002-cb12b27d-a0c7-4aad-9d70-29cf95a80af1.png)

Lastly this script is used for the spheres so that they get a random range of speed whenever they spawn also so they disappear when they go past a certain range.

# Final Setup

In this part u can see what the setup is for the previously added scripts in the agent.

![image](https://user-images.githubusercontent.com/78807955/233461734-f7c8de75-70fb-4721-a5ef-8ccd99e1606a.png)

![image](https://user-images.githubusercontent.com/78807955/233461870-c5765571-b4c5-4605-8abf-28f06da9f937.png)

# Testing the Environment

The training properties are defnied in the config file. The file is a yaml file found in the project.

```
behaviors:
  JumperAgent:
    trainer_type: ppo
    hyperparameters:
      batch_size: 10
      buffer_size: 100
      learning_rate: 3.0e-4
      beta: 5.0e-4
      epsilon: 0.2
      lambd: 0.99
      num_epoch: 3
      learning_rate_schedule: linear
      beta_schedule: constant
      epsilon_schedule: linear
    network_settings:
      normalize: false
      hidden_units: 128
      num_layers: 2
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 100000
    time_horizon: 64
    summary_freq: 2000
```

To test the environment u can have to open anaconda terminal and go to the where your config folder is located of the project and use this command: 

```
mlagents-learn Jumper_config.yaml --run-id=Jumper
```
To visualize your results u can use Tensorboard.
