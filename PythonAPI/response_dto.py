import json

class ResponseDTO(object):
    def __init__(self, type, data_type, message):
        self.type = type
        self.data_type = data_type
        self.message = message

    def to_json(self):
        return json.dumps(self.__dict__)

if __name__ == "__main__":
    test = ResponseDTO("status", "sadasdsadsad")
    print(test.to_json())


