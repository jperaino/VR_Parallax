# VR_Parallax
_Jim Peraino_

This project is built as the capstone project for the Udacity Virtual Reality Nanodegree program. It is a prototype for a VR interface that tests methods of interaction and modes of perspectival awareness in a VR environment.

_Built for iOS using Unity and Google's Cardboard SDK_

__[Video Walkthrough Link](https://vimeo.com/221818092)__

## Achievements (total 1,750): ##

#### Fundamentals (500 points): ####
- __Scale Achievement__ (100 points)
    _The user is able to adjust the scale of the great hall by selecting the lower of the two boxes. They can then understand the change in scale by moving and watching that the spheres appear to fall much more slowly (though in reality, they are simply covering more ground)._
- __Animation Achievement__ (100 points)
    _When the cube in the center of the scene is pressed, the spheres are animated into a new position. From the user's point of view, it appears that the spheres are simply growing in size, however, when the user moves his/her position, they can see that the spheres have actually moved in space._
- __Locomotion Achievement__ (100 points)
    _Users can click on arrows to move left and right, and locomotion is defined by iTween's methods._
- __Physics Achievement__ (100 points)
    _When the users look at spheres, the spheres are dislodged and fall to the bottom of the scene. A sound is played upon each collision. At the end of gameplay, the spheres all fall._
- __Empathy Achievement__ (100 points)
    _This game is a methaphor for empathetic thought. No lighting is applied to the spheres so that they become abstracted in space. From one point of view, there is chaos, but upon shifting his/her position, the user can see a coherent and familiar space. You can look at one thing from two different points of view and see something completely different._
    
#### Completeness (750 points): ####
- __Gamification Achievement__  (250 points)
    _The goal of the game is to make as many spheres drop as possible within the alloted time. A scoreboard shows the time remaining and the number of spheres remaining in the scene. A lower score is a better outcome._
- __Alternative Storyline Achievement__ (250 points)
    _At the beginning of the game, the user is prompted with two alternative experiences: an easy version with fewer spheres, and a harder version with more spheres._
- __3D Modeling Achievement__ (250 points)
    _The arrows for navigation were modeled in Rhino. Additionally, the sphere locations were generated by modeling an archway in rhino, and then using Grasshopper to export the point locations, which could then be fed into the objectMaker script._
    
#### Challenges (500 points): ####
- __User Testing achievement__ (250 points x 2)
    - _Two rounds of user testing were held to develop the user interface and to improve user experience._
    - _The first round focused on locomotion, and tested several different types of movement. While earlier iterations did not use tweening in an attempt to avoid motion sickness, users reported that animating the movement made it more clear what was happening as their perspective shifted, and did not result in motion sickness._
    - _The second round of user testing focused on the UI, and resulted in user controls that move with the user as they change positions rather than staying in a globally fixed location._
    
    
_Note regarding rubric item: "Experience must convey an emotion": My strategy here was to use abstracted materials and geometries to create a disembodied emotion. The background colors are calm and reminiscent of a summer evening, and the pure geometries aim to create a sense of focus, eliminating distraction._

_Note regarding rubric item: "Use at least 3 spatial audio clips": Each sphere in the scene is a GVR audio source, meaning there are close to 1,000 sources. They were carefully calibrated to avoid performance issues in the final animation where the spheres fall to the ground by only allowing the sound to be triggered upon collisions during gameplay._
