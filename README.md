# TP-Morpion-3D

Pour tester si le joueur à gagner, on test face par face si il y a une ligne ou une diagonale qui est complète.
Pour les lignes, on vérifie si au moins 3 points ont au moins 2 coordonnées en communs.
Pour les diagonale, on vérifie à partir du centre d'une face si les coins qui forments la diagonale font parti de la liste des coups joués
Pour la grande diagonale du cube, on vérifie si le point (0,0,0) a été joué et si il y a dans la liste des coordonnée deux point qui sont opposé (cordonnées de l'un égale à -1 fois les coordonnées de l'autre)
