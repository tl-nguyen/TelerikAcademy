define(['chai', 'httpReq'], function (chai, httpReq){
    var expect = chai.expect;

    describe('#httpReq', function () {
        var url = 'http://crowd-chat.herokuapp.com/posts';

        it('Fetching some data', function (done) {
            var data;

            httpReq.getJSON(url)
                .then(function (chats) {
                    data = chats;

                    expect(data).to.have.length.above(1);
                    done();
                });

        });

        it('Posting to the crowd chat', function (done) {
            var data = {
                user: 'Unit tester',
                text: 'testing with mocha and chai :-D'
            };

            httpReq.postJSON(url, data)
                .then(function (success) {
                    expect(success).to.be.ok;
                    done();
                });
        });
    });
});