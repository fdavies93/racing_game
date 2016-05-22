#Car Project Report: Frank Davies

##Summary

In this project, I took the role of UI programmer. This is because I'm taking the Advanced Programming module as an outside option, and so due to other commitments couldn't take a central gameplay programming role. It was felt by the group that UI development, while a nice addition, was not necessary to complete the project, and therefore that it suited my relative lack of time to spend on the project.

I chose to employ the MVC model of user interface architecture as it's an industry-proven, flexible, and extensible approach to developing UI. This meant that I could develop the appearance, control, and abstract functionality of the UI separately from one another.

While I believe my general approach to this project was correct, I could have improved it had I considered the possibility of using prefabs for menus in order to expedite development, rather than attempting to hand-code the creation of almost all objects. The MVC architecture, while perfectly suitable, could probably have been improved in its implementation had I considered the more modern approach of MVP (Model-View-Presenter), where all interaction logic is handled by the presenter and the model remains a passive agent.

##Development

I have quite an architectural, top-down approach to programming in general, and so for this project I chose to draw on the MVC (Model-View-Controller) model of user interface architecture, which I'd heard about in theory but wanted to try developing. While I would have enjoyed testing some of my theoretical approaches to user interface design, the rest of the group had a clear plan for the interface which employed very traditional controls. In addition, the lack of time I had to spend on the project meant that the time spent to develop new types of control would have been unfeasibly long.

The first thing I did while developing this project was to plan out the way I saw the menu functioning. As I already knew this in the abstract, there was no need for me to draw out architectural plans. Instead I began building the core of the program - the abstract menu model - and considering how this would link with the controller and view objects. I did this by simultaneously building a basic view and controller object and implementing their functionality alongside the abstract model.

A menu is laid out like so, as shown in the Unity hierarchy:

* Menu object: This contains the abstract logic for all menus.
  * View object: This contains the logic used to generate a particular view, and parents the view options. There can be multiple attached to the same menu.
    * View options: These are passive objects which store data on how a particular view option is displayed, and which are used by the View script to build the interface the user sees.
  * Control object: This has the script used to handle user input attached. There can only be one.
  * Options group: This parents the menu options but does nothing itself.
    * Menu options: These contain UnityEvents used to handle events such as an option being selected or highlighted.

After developing this basic structure, I spent my time developing the basic view into the more sophisticated horizontal and vertical views which are seen in-game in their basic iterations.

I then moved onto developing the most complex of the views: the spinner, which is used to display car and track selection menus. This took some time to perfect, largely due to the complexities in algorithm caused by the boundary conditions of rotating from above 0 to 360 and from below 360 to above 0. The imperfect nature of Unity rotations due to the need to avoid Gimbal Lock also didn't help this algorithm, which is a little messy as a result. However, I managed to get it into a satisfactory state for the final project.

The menus were still a little complex and not very aesthetically pleasing at this point, so I spent some time polishing them to add a number of features, including adding backgrounds, justifying the menus relative to the screen, and selection of both text and foreground colours. This would allow for the look and feel of the menu to be tweaked by designers from the Unity inspector and so gave a bit more flexibility to the menu development process.

I planned to spend the last few days before the final presentation of the project integrating my menu work with the rest of the game, but was pleasantly surprised to find that the rest of the group had already done this as part of their process of finalising.

##Analysis

I did a number of things well in this project. For example, by taking an architectural approach to the menu code, I made it relatively easy for this code to be integrated with the rest of the project. This also made it easy for me to code the views (which turned out to be the most complex part of the code) without having to worry about how the rest of the menu code would interact with the view object. My experiences therefore reinforced my belief in clean code and well-planned code design, and I will continue to work on developing my architectural skills and this hygienic approach to code in the future.

I also took a great deal of care to ensure that my changes to code worked well with version control. Most of the time which I spent on this project was used working in a separate scene called menu-test. This was extremely useful as it allowed me to work on UI features without having to worry about how it interacted with the rest of the game, and further contributed to the hygienic, modular nature of my code. It also meant that changes which I made in my scene wouldn't influence the rest of the game. Another way I ensured my code worked well with version control was to organise menu assets in a separate folder structure from the rest of the game script, so as to make at more difficult for other members of the team to accidentally modify UI code.

While I worked on my part of this project relatively autonomously, I probably could have been more involved with the main development process. There were upsides and downsides to my autonomy from the rest of the group. On the positive side, not being able to be in contact with the rest of the group a lot forced me to consider how my designs would work with the rest of the code without actually knowing what that code was, making it far more modular than it might otherwise have been. On the negative, this led to delays in my work as I struggled to find times I could meet with the rest of the group. Part of this was my fault and part of it was an unavoidable consequence of the composition of our group. For example, I could not make weekend meetings easily because I'm a commuter, but several members of the team who have found jobs could only work weekends. On the whole, though, I managed to work with the rest of the team fine, although often from a distance.

The main problem with my approach was that I hadn't considered the use of prefabs to create menus rapidly from pre-made designs, without having to hand-code every detail of a menu's structure and layout. While I moved towards this approach near the end of the project, development was very slow and error-prone until I adopted it. This was particularly problematic because I didn't have much time to spend on the project in the first place.

In addition, the architecture of the interface could have been improved slightly had I taken into consideration that the MVC model is generally considered a little messy relative to the more modern MVP model, which completely removes logic from the view by pushing it to the presenter and having the two interact through events. However, for a project as small in scope as this one, the architectural improvement would have been relatively slight, and building a true event queue would have taken time better spent on other things.

I could also have made the usability of the interface very slightly better by writing a custom interface for the Unity editor. This would have allowed, for example, completely removing view options and having all aspects of the menu be able to be designed from within a single Unity inspector screen. Again, this is a feature I might have added if I'd had the luxury of time, but not one which I considered essential, as I was both designing and coding the UI and so didn't need to make the process of UI design comprehensible to anyone but myself.

My overall approach to the project was fine. However, the time I lost hand-coding menus made it a little difficult to finish on time, and also prevented me from adding other features which might have added to the final product. A lack of communication with the rest of the team was also a minor difficulty, but because of how I approached the design of the code, this wasn't a big issue. My part of the project was therefore successful although not superb, and I will continue to use an architectural, system-driven approach to coding in the future, while attempting to spend more time considering how I can increase my development speed so as to avoid the problems I had on this project.
