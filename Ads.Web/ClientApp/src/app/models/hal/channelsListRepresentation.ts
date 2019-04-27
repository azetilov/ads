
import { Channel } from "../channel.model";

export class ChannelsListRepresentation {
  totalResults: number;
  _embedded : {
    channels: Array<Channel>
  };
}
