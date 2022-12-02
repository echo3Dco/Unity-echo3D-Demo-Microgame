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
* Open the Demo scene in Unity.
* [Set the API key](https://docs.echo3d.co/quickstart/access-the-console) and Entry IDs on the echo3D script using the Inspector for the objects.
![APIKeyandEntryId](https://user-images.githubusercontent.com/99516371/195749269-f7a43477-b67a-49e8-a212-6abdb9c948fd.png)<br>
![NEWAPIKeyandEntryID](https://user-images.githubusercontent.com/99516371/205407613-b746840f-8e8a-4ec8-b056-a680395dfab4.png)<br>

* [Type your Secret Key](https://docs.echo3d.co/web-console/deliver-pages/security-page#secret-key) as the value for the parameter secKey in the file Packages/co.echo3D.unity/Runtime/Echo3DHologram.cs. _(Note: Secret Key only matters if you have the Security Key enabled). You can turn it off in the Security options in your echo3D console._
![NEWSecKey2](https://user-images.githubusercontent.com/99516371/195749308-b2349a3b-7e43-4d3c-8f09-fbfa9d3cb0be.png)<br>
* (Optional) To move or edit the assets live in your project, check the boxes for “Editor Preview” and “Ignore Model Transforms”. At the top of your project, click Echo3D > Load Editor Holograms <br>
![EditorPreviewAndIgnoreModelTransforms](https://user-images.githubusercontent.com/99516371/195749348-dc0b06ad-efa6-4dbd-962f-0119b5c33ea0.png)<br>
![LoadHolograms](https://user-images.githubusercontent.com/99516371/195749354-b2295183-f877-444a-af22-ed87ffb17705.png) <br>


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


