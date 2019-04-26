
import { AdChannel } from "../ad-channel";

export class ChannelsListRepresentation {
  totalResults: number;
  _embedded : {
    adsChannels: Array<AdChannel>
  };
}
