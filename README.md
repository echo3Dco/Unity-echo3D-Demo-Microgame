# Unity-echo3D-NextNav-Demo
Integrate the echo3D SDK into NextNav's Pinnacle demo so we can manage assets through the echo3D cloud.

## Version
[Unity 2021.2.7](https://unity3d.com/get-unity/download/archive)

## Register
Don't have an echo3D API key? Make sure to register for FREE at [echo3D](https://console.echo3D.co/#/auth/register). <br>
Register for your free [NextNav](https://partner.nextnav.com/PartnerPortalRegisterNN?startURL=/s/&utm_campaign=Echo3D%20Portal%20Registrations&utm_source=echo3d&utm_medium=landing%20page) trial [here](https://partner.nextnav.com/PartnerPortalRegisterNN?startURL=/s/&utm_campaign=Echo3D%20Portal%20Registrations&utm_source=echo3d&utm_medium=landing%20page).

## Video
See it on Youtube [here](https://youtu.be/aDTd2pvtn-g).

## Steps
* [Install the echo3D Unity SDK](https://docs.echo3D.co/unity/installation). Troubleshoot [here](https://medium.com/r/?url=https%3A%2F%2Fdocs.echo3d.co%2Funity%2Ftroubleshooting%23im-getting-a-newtonsoft.json.dll-error-in-unity). <br>
![echo3D SDK](https://user-images.githubusercontent.com/99516371/186556619-ffdab024-bee3-40f8-8876-d5210de03603.png)
* In your [NextNav](https://partner.nextnav.com/PartnerPortalRegisterNN?startURL=/s/&utm_campaign=Echo3D%20Portal%20Registrations&utm_source=echo3d&utm_medium=landing%20page) account, download and import their Unity Plugin. You can also clone our [repo](https://github.com/echo3Dco/Unity-echo3D-NextNav-Demo/) for the project. <br>
![NextNavDash](https://user-images.githubusercontent.com/99516371/186556566-ef7e25cb-5811-4757-83ed-d77126c9ea2d.png)
* Download the 3D model(s) from the Assets/Models folder in the project: DroneModel and Wing 01.
* Go to echo3D console and click ["Add to Cloud"](https://docs.echo3D.co/quickstart/add-a-3d-model) and upload the models DroneModel and Wing 01 (You will repurpose the Wing 01 asset 4 times total for each drone wing in Unity).
* [Uncheck](https://docs.echo3d.co/web-console/deliver-pages/security-page) the "Enable Secret Key" box in your echo3D console or [add the echo3D API key](https://docs.echo3d.co/unity/using-the-sdk) to the echo3D.cs script so the objects can appear in Unity.
* Open the Demo scene in Unity.
* [Set the API key](https://docs.echo3D.co/unity/using-the-sdk) and entry IDs on the echo3D script using the Inspector for the DroneModel and Wing 01 - Wing 04 objects in the Hierarchy. Wing 01 - Wing 04 will have the same API and entry ID since they are the same object. <br>
 ![APIKeyandEntryId](https://user-images.githubusercontent.com/99516371/186558297-4e4fad1a-bdd0-4a79-ad23-967800b44115.png)<br>
 ![Hierarchy](https://user-images.githubusercontent.com/99516371/186558308-f3ea600e-8aea-46c7-91f7-ce021aa057ed.png)<br>

## Run
Press Play in Unity and see the echo3D drone appear from the cloud.

## Learn more
Refer to our [documentation](https://docs.echo3D.co/unity/) to learn more about how to use Unity and echo3D.

Refer to [NextNav's](https://partner.nextnav.com/PartnerPortalRegisterNN?startURL=/s/&utm_campaign=Echo3D%20Portal%20Registrations&utm_source=echo3d&utm_medium=landing%20page) documentation.

## Support
Feel free to reach out at [support@echo3D.co](mailto:support@echo3D.co) or join our [support channel on Slack](https://go.echo3D.co/join). 

## Screenshots
![Screenshot1](https://user-images.githubusercontent.com/99516371/186558505-8596fc9f-ee39-48cd-bc39-1ac44d4691b3.png)<br>

![Screenshot2](https://user-images.githubusercontent.com/99516371/186558514-7cfd169f-6070-444d-a442-2c8e69d5eecc.png)<br>

![Screenshot3](https://user-images.githubusercontent.com/99516371/186558522-7a4b53c8-c803-4ef8-9aa0-c938a31f6b2e.png)<br>

![Screenshot4](https://user-images.githubusercontent.com/99516371/186558528-acea1df9-b8de-46ea-bc0a-1c138a9e4176.png)<br>


