# Huom
Data kansiossa on luokka joka kuvaa lähetettävän json datan rakenteen, jossa on vain Artikkeliid ja ArtikkeliNimi jotka select lista tarvitsee.

Views/artikkelit/create.cs tiedostossa on scripti joka hakee datan artikkelit controllerista ja muodostaa ylimääräisen selectlistin create lomakkeeseen javascriptillä.

Artikkelit controllerissa on kontrolleri-metodi joka lähettää json datan selaimeen kun sitä pyydetään em. scriptissä
