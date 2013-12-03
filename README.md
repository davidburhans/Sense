Sensé: Configure your body's desktop
=========
Sensé is a wearable electronics device that communicates with the user via low-resolution epidermal stimulation. In other words, it is a handful of vibrating motors that allow you to consume information by vibrating in consistent patterns against your skin.

What would this be used for? 
- Reading (Braille)
- GPS/Directions (Automated route guidance while walking, biking, or driving)
- Compass (Always know North)
- Alarms/Notifications
- Biometrics (combine with notifications or use while working out for constant feedback)
- Clock (Tell time intuitively)
- Animal training (pain-free remote controlled collar)

Wait, WTF!?
-----------
###Surely this isn't possible. How can you expect to achieve that with just some vibrating motors?

Quite frankly, I don't see any reason why it *shouldn't* work. From what I understand of how the nervous system works, this concept *does* work, it is just going to be a matter of providing the proper stimulus and associating that stimulus with meaningful information in a consistent manner. Most people have heard of Pavlov's dog, this is essentially the same concept.

Preliminary reports of wearable compass-belts stated that the sense of direction imparted by the belts was quickly interpreted and incorporated into the user's mental framework. They claimed that the new information helped them naturally discern the relationships between different locations within the city. While this is not necessarily an expected result, neuroplasticity explains it.

####Neuroplasticity (mode of operation)
Basically, this means your brain changes in response to its environment. Makes sense -- that's what learning is. What I find fascinating is that your brain doesn't really care what its environment is, as long as it continues existing. This means we can trick our brain into thinking we have senses that we do not. Let me repeat: we can trick our brain into thinking we have senses that we do not.

This starts to get wacky when you take a study done by the University of Wisconsin -- Madison into account. This study demonstrated that a blind person was able to "see" again by using a specialized scan-line camera. The camera was attached to their tongue by electrodes. Not great resolution on the sight, but it could be used to navigate obstacles.

If a person can see with their tongue, why can't they learn to read with their arm?

Hardware
--------
The software is made for the Netduino Plus 2, but is intended for prototype purposes only. The software should be easily adapted to any other platform to reduce hardware costs.

The end-goal is to have the software suite running on a fairly powerful mobile computing platform (a smart phone) communicating over bluetooth (or similar technology) to wearable devices placed around the body.

Software
--------
This prototype is being written using the .Net Micro Framework v4.2 and Visual Studio 2010 in C#.

Eventually, I plan on turning this into a management suite for the Sensé device. This way, you can have a whole suite of sensor data being translated and sent to different Sensé devices. 

[david burhans]: github.com/davidburhans