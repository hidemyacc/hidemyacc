import requests

API_URL = 'http://127.0.0.1:12368'

class Hidemyacc(object):
    def start(self, profile_id):
        data = {}
        response = requests.post(API_URL + '/profiles/start/' + profile_id, data = data).json()
        return '127.0.0.1:' + str(response['data']['port'])

    def stop(self, profile_id):
        response = requests.post(API_URL + '/profiles/stop/' + profile_id).json()
        return response
