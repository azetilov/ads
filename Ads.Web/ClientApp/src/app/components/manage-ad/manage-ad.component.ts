import {Component, OnInit} from '@angular/core';
import {Channel} from "../../models/channel.model";
import {AdChannel} from "../../models/ad-channel.model";
import {AdsService} from "../../ads.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Ad} from "../../models/ad.model";
import {FormsModule} from '@angular/forms';
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'manage-ad',
  templateUrl: './manage-ad.component.html',
})
export class ManageAdComponent implements OnInit {
  public channels: Channel[];
  public adsChannels: AdChannel[];
  public ad: Ad;
  public selectedChannel: number;
  public newAdName: string;

  constructor(private adsService: AdsService,
              private route: ActivatedRoute,
              private router: Router
  ) {
    adsService.getChannels().subscribe(result => {
      this.channels = result._embedded.channels;
    }, error => console.error(error));

    adsService.getAd(this.route.snapshot.paramMap.get('id'))
      .subscribe(result => {
        this.ad = result;
        console.log(result);
        this.loadChannels();
      });
  }

  ngOnInit() {}

  addChannel(adId: number, channel: AdChannel) {
    var adChannel = new AdChannel();
    adChannel.name = `${this.ad.name} - ${channel.name}`;
    adChannel.channel = this.channels[this.selectedChannel];
    adChannel.ad = this.ad;
    this.adsService.addChannel(adChannel).subscribe(() => {
      this.channels.push(adChannel);
      this.loadChannels();
    });
  }

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
