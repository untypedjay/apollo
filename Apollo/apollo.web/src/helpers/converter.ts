const dateOptions = { weekday: 'short', year: 'numeric', month: 'long', day: 'numeric' };
const timeOptions = { hour: '2-digit', minute: '2-digit' };

export function formatTimeStamp(timeStamp: string): string {
  const date = new Date(timeStamp);
  return `${date.toLocaleDateString('en-US', dateOptions)} | ${date.toLocaleTimeString('en-US', timeOptions)}`;
}

export function getMovieTitleArray(): string[] {

  return ['Blast from the Past', 'Kokowäääh', 'The wolf of wallstreet'];
}

export function getCinemaHallNameArray(): string[] {
  return ['IMAX Shizzle', 'SAAl 3', 'SUPREME SAAL 4'];
}