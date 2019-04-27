
import { AdChannel } from "../ad-channel.model";

export class AdsChannelsListRepresentation {
  totalResults: number;
  _embedded : {
    adsChannels: Array<AdChannel>
  };
}
