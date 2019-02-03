# AR_Assignment1

## PREPARATION
• Download and print the templates for image targets spaceship set and earth from the Exercises page on Blackboard.

• For all tasks, it is mandatory to set the World Center Mode of your ARCamera to DEVICE.

• Review the code that implements the rotations and positions in the planetary system using matrix multiplications. It can be found on the Exercises page on Blackboard. Tinker a bit with the code, change the order of the multiplications and see the effect. Make sure you understand the solution. This will prepare you to solve some tasks in the following assignment.

## Transformations and coordinate systems
### TASKS

a) 
- [ ] 1pt Generate individual image targets from each of the images of the template. Use exact
measurements and be consistent with your units.
```diff
- Show your image files and explain how you measured the size of the printouts and how these measurements relate to the image files.
```

b) 
- [x] 2pt ; You will realize that some of the image targets have a very bad Augmentable rating in the
Vuforia target manager. Add visual features to your image targets or completely rework them.
You can follow this guide. Keep it close to what the targets depict, e.g., the spaceship should
still be recognizable as such when looking at it. Every target has to have a rating of at least 3
stars in the end.
```diff
- Why was it initially hard to track for Vuforia and why did your features improve it?
- Why was it not necessary for some of the targets?
```

- [x] 0.5pt Achieve an Augmentable rating of at least 4 stars per target while keeping them close to
what they depict.

c) 
- [ ] 2pt Create a scene with the space shuttle and the landing lane. Attach a small patch (e.g.,
Quad) to the space shuttle and assign it a new material, using the Unlit → Color shader. Set the
color of the material at runtime depending on how much the space shuttle is aligned with the
landing lane. Use the dot products of the base vectors of both GameObjects. The patch color
should go from red (not aligned) to green (completely aligned).


d) 
- [ ] 2pt Create a scene with the space shuttle and the large earth image target. Attach a GameObject
to the nose of the space shuttle. Transform the nose’s localPosition to get from the
space shuttle’s local coordinate system to the earth’s local coordinate system. Do this by first
creating a Matrix4x4 (based on the GameObjects’ model matrices) that transforms between
the shuttle’s and earth’s local coordinate systems.
```diff
- Imagine having to transform very many points. Which of the steps above have to be done once per frame and which ones for each point?
```

- [ ]1pt Check whether or not the nose is over the (round) image of the earth, using the local xyzcoordinates you just computed. You can achieve that by implementing cylindrical boundaries
for the local coordinate system, i.e., testing how far away (x, z) is from the origin and checking
whether y is below a threshold. You can choose an appropriate cylinder height, i.e., maximum
y value. If they are within the boundaries, display ”North” or ”South” depending on whether
the nose is over the northern or southern hemisphere.



e) 
- [ ] 2pt Create a scene with the Millennium Falcon and an enemy ship (TIE Fighter or Interceptor).
Assign a button or key stroke to shoot a laser from the Falcon to its viewing direction. Check
whether the ray hits the enemy ship and indicate a hit (e.g., with an explosion). Visualize the
ray: Generate a OnRenderObject method and use GL.Begin(GL.Lines).
- [ ] 0.5pt Shoot two lasers from the two front cannons (see Figure 1). Instead of using child
GameObjects for your cannons, define the local positions of the cannons and use the Falcon’s
position and rotation to get the cannons’ world positions.
1pt Shoot a laser from the top cannon (see Figure 1). Do not use child objects, but define your
local coordinates in code. The top cannon should be 2.5cm above the spaceship. Define yaw
and pitch variables to adjust the angle of the top cannon and apply the rotation to the direction
of the laser. You can use Quaternion.Euler to create a rotation from your angles.