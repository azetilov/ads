import { Component} from '@angular/core';
import {Ad} from "../../models/ad.model";
import {Channel} from "../../models/channel.model";
import {AdChannel} from "../../models/ad-channel.model";
import {AdsService} from "../../ads.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public ads: Ad[];
  public channels: Channel[];
  public adsChannels: { [s: string]: AdChannel[]; } = {};

  constructor(
    private router: Router,
    private adsService: AdsService) {
    this.init(adsService);
  }

  init(adsService: AdsService) {
    adsService.getChannels().subscribe(result => {
      this.channels = result._embedded.channels;
    }, error => console.error(error));
    adsService.getAds().subscribe(result => {
      this.ads = result._embedded.ads;
      this.ads.forEach(ad => {
        adsService.getAdChannels(ad.id).subscribe(result => {
          this.adsChannels[ad.id] = result._embedded.adsChannels;
        }, error => console.error(error));
      })
    }, error => console.error(error));
  }

  manageAd(ad: Ad) {
    return this.router.navigate(['manage', ad.id]);
  }
}
