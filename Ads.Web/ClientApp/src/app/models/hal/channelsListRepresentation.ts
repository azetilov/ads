
import { Channel } from "../channel";

export class ChannelsListRepresentation {
  totalResults: number;
  _embedded : {
    channels: Array<Channel>
  };
}
