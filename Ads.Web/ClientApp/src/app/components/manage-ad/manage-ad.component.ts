import {Component, OnInit} from '@angular/core';
import {Channel} from "../../models/channel.model";
import {AdChannel} from "../../models/ad-channel.model";
import {AdsService} from "../../ads.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Ad} from "../../models/ad.model";

@Component({
  selector: 'manage-ad',
  templateUrl: './manage-ad.component.html',
})
export class ManageAdComponent implements OnInit {
  public channels: Channel[];
  public adsChannels: AdChannel[];
  public ad: Ad;

  constructor(private adsService: AdsService,
              private route: ActivatedRoute,
              private router: Router
  ) {
    console.log(this.route.snapshot.queryParamMap);
    adsService.getAd(this.route.snapshot.paramMap.get('id'))
      .subscribe(result => {
        this.ad = result;
        console.log(result);
        this.loadChannels();
      });
  }

  ngOnInit() {}

  deleteChannel(adId: number, channelId: string) {
    if (confirm("Are you sure?")) {
      this.adsService.deleteChannel(adId, channelId).subscribe(() => {
        this.loadChannels();
      });
    }
  }

  loadChannels() {
    this.adsService.getAdChannels(this.ad.id).subscribe(result => {
      console.log(result._embedded);
      this.adsChannels = result._embedded.adsChannels;
    }, error => console.error(error));
  }
}
