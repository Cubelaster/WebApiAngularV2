import { WebApiAngularV2Page } from './app.po';

describe('web-api-angular-v2 App', () => {
  let page: WebApiAngularV2Page;

  beforeEach(() => {
    page = new WebApiAngularV2Page();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
